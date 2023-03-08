using Terraria.Audio;
using static Terraria.ModLoader.ModContent;
using RandomContentModIII.Content.Projectiles;
using RandomContentModIII.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class SakuyaKnifeBarrage : ModItem
	{
		private static readonly Color[] itemNameCycleColors = 
		{
			new Color(148, 3, 252),
			new Color(148, 3, 252),
			new Color(3, 161, 252),
			new Color(3, 161, 252),
		};

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sakuya's Knife Barrage");
			Tooltip.SetDefault("A powerful set of knives that uses mana to create copies of themselves.\nWill shoot knives in 1 directions in a 90 degree angle.\nHeals the user for 5 health on hit per knife.\nMay cause lag\n'What happens to the dead if they starve themselves to death?'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod))  //thanks to PaperLuigi for letting me use this code <3
			{
				Item.damage = 450;
			}
			else
			{
				Item.damage = 175;
			}
			Item.width = 58;
			Item.height = 58;
			Item.rare = ItemRarityID.Purple;
			Item.useTime = 10; 
			Item.useAnimation = 10; 
			Item.useStyle = ItemUseStyleID.Swing;
			Item.autoReuse = true; 
			Item.UseSound = SoundID.Item39;
			Item.DamageType = DamageClass.Magic; 
			Item.knockBack = 6f; 
			Item.noMelee = true; 
			Item.value = 1000000;
			Item.mana = 15;
			Item.shoot = ModContent.ProjectileType<SakuyaKnife>(); 
			Item.shootSpeed = 25f;
			Item.noUseGraphic = true;
			Item.channel = true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float numberProjectiles = 22 + Main.rand.Next(2); 
			float rotation = MathHelper.ToRadians(45);

			position += Vector2.Normalize(velocity) * 45f;

			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f; 
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}

			return false; 
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			int numColors = itemNameCycleColors.Length;
			
			foreach (TooltipLine line2 in tooltips) {
				if (line2.Mod == "Terraria" && line2.Name == "ItemName") {
					float fade = (Main.GameUpdateCount % 60) / 60f;
					int index = (int)((Main.GameUpdateCount / 60) % numColors);
					int nextIndex = (index + 1) % numColors;

					line2.OverrideColor = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[nextIndex], fade);
				}
			}
		}

		public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod)) //credit to PaperLuigi for letting me use the code from his mod <3
            {
                CreateRecipe(1)
                .AddIngredient<SakuyaKnives>()
                .AddIngredient(calamityMod.Find<ModItem>("CosmiliteBar").Type, 10)
				.AddIngredient(calamityMod.Find<ModItem>("AuricBar").Type, 7)
                .AddIngredient(ItemID.Razorpine)
				.AddIngredient(ItemID.LunarBar, 25)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
            }
            else
            {
                CreateRecipe(1)
                .AddIngredient<SakuyaKnives>()
                .AddIngredient(ItemID.Razorpine)
				.AddIngredient(ItemID.NebulaBlaze)
				.AddIngredient(ItemID.LunarBar, 25)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
            }
		}
	}
}