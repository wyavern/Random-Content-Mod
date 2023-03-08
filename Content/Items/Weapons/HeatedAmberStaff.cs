using System;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RandomContentModIII.Content.Projectiles;
using RandomContentModIII.Content.Rarities;
using Terraria.Audio;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System.Collections.Generic;
using RandomContentModIII.Content.Buffs;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class HeatedAmberStaff : ModItem
	{
		private static readonly Color[] itemNameCycleColors = 
		{
			new Color(255, 115, 0),
			new Color(255, 115, 0),
			new Color(255, 246, 84),
			new Color(255, 246, 84),
		};

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Overheated Amber Staff");
			if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod))  //thanks to PaperLuigi for letting me use this code <3
			{
				Tooltip.SetDefault("Fires a powerful fire beam.\nThe beam can penetrate a huge amount of enemies at once.\nThe beam has been heated by the Sun itself.");
			}
			else
			{
				Tooltip.SetDefault("Fires a powerful beam.\nThe beam can penetrate a huge amount of enemies at once.");
			}
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod))  //thanks to PaperLuigi for letting me use this code <3
			{
				Item.damage = 999;
				Item.useTime = 35;
				Item.useAnimation = 35;
			}
			else
			{
				Item.damage = 333;
				Item.useTime = 15;
				Item.useAnimation = 15;
			}
			Item.DamageType = DamageClass.Magic;
			Item.crit = 50;
			Item.width = 128;
			Item.height = 128;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.scale = 1;
			Item.mana = 20;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = 1000000;
			Item.rare = ModContent.RarityType<ModRarity2>();
			Item.UseSound = SoundID.Item4;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<HeatedBeam>();
			Item.shootSpeed = 10;
			Item.channel = true;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) 
		{
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
			CreateRecipe()
				.AddIngredient(ItemID.Amber, 100)
                .AddIngredient(ItemID.HeatRay, 1)
                .AddIngredient(ItemID.AmberStaff, 1)
                .AddIngredient(ItemID.FragmentSolar, 50)
				.AddIngredient(ItemID.LakeofFire)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
