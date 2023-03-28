using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using RandomContentModIII.Common.Players;
using RandomContentModIII.Content.Items.Weapons;
using Terraria.GameContent;
using System.Collections.Generic;

namespace RandomContentModIII.Common.UI.ExampleResourceUI
{
	internal class SoulflowBar : UIState
	{
		private UIText text;
		private UIElement area;
		private UIImage barFrame;
		private Color gradientA;
		private Color gradientB;

		public override void OnInitialize() {

			area = new UIElement();
			area.Left.Set(-area.Width.Pixels - 600, 1f); 
			area.Top.Set(30, 0f); 
			area.Width.Set(182, 0f); .
			area.Height.Set(60, 0f);

			barFrame = new UIImage(ModContent.Request<Texture2D>("RandomContentModIII/Common/UI/SoulflowBarFrame")); 
			barFrame.Left.Set(22, 0f);
			barFrame.Top.Set(0, 0f);
			barFrame.Width.Set(138, 0f);
			barFrame.Height.Set(34, 0f);

			text = new UIText("Hold or equip a soulflow item!", 0.8f); 
			text.Width.Set(138, 0f);
			text.Height.Set(34, 0f);
			text.Top.Set(40, 0f);
			text.Left.Set(0, 0f);

			gradientA = new Color(84, 213, 222);
			gradientB = new Color(165, 47, 204); 
			area.Append(text);
			area.Append(barFrame);
			Append(area);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch) {
			base.DrawSelf(spriteBatch);

			var modPlayer = Main.LocalPlayer.GetModPlayer<SoulflowPlayer>();
			float quotient = (float)modPlayer.SoulflowCurrent / modPlayer.SoulflowMax2; 
			quotient = Utils.Clamp(quotient, 0f, 1f); 
			Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
			hitbox.X += 12;
			hitbox.Width -= 24;
			hitbox.Y += 8;
			hitbox.Height -= 16;
			int left = hitbox.Left;
			int right = hitbox.Right;
			int steps = (int)((right - left) * quotient);
			for (int i = 0; i < steps; i += 1) {
				float percent = (float)i / steps; // gradient that grows as the bar fills
				//float percent = (float)i / (right - left); // usual gradient
				spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Color.Lerp(gradientA, gradientB, percent));
			}
		}

		public override void Update(GameTime gameTime) {
			var modPlayer = Main.LocalPlayer.GetModPlayer<SoulflowPlayer>();
			text.SetText($"Soulflow: {modPlayer.SoulflowCurrent} / {modPlayer.SoulflowMax2}");
			base.Update(gameTime);
		}
	}

	class SoulflowUISystem : ModSystem
	{
		private UserInterface SoulflowBarUserInterface;

		internal SoulflowBar SoulflowBar;

		public override void Load() {
			if (!Main.dedServ) {
				SoulflowBar = new();
				SoulflowBarUserInterface = new();
				SoulflowBarUserInterface.SetState(SoulflowBar);
			}
		}

		public override void UpdateUI(GameTime gameTime) {
			SoulflowBarUserInterface?.Update(gameTime);
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (resourceBarIndex != -1) {
				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
					"RandomContentModIII: Soulflow Bar",
					delegate {
						SoulflowBarUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}
