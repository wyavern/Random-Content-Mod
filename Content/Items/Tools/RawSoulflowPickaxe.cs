//using ExampleMod.Content.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RandomContentModIII.Content.Items.Other;

namespace RandomContentModIII.Content.Items.Tools
{
	public class RawSoulflowPickaxe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Weird how this pickaxe is able to mine infected stone"
			+ "\nSeems like raw soulflow is much more durable than it looks."
			+ "\nCan mine Meteorite"
			+ "\n[c/7914c7:-Soulflow item-]");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 1); // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.pick = 64; // How strong the pickaxe is, see https://terraria.gamepedia.com/Pickaxe_power for a list of common values
		}

		/*public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Sparkle>());
			}
		}*/

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<RawSoulflow>(12)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}