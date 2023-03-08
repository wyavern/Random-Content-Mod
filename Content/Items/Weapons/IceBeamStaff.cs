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
	public class IceBeamStaff : ModItem
	{
		private static readonly Color[] itemNameCycleColors = 
		{
			new Color(0, 242, 255),
			new Color(0, 242, 255),
			new Color(0, 5, 150),
			new Color(0, 5, 150),
		};

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Icy Shadowbeam Staff");
			if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod))  //thanks to PaperLuigi for letting me use this code <3
			{
				Tooltip.SetDefault("Fires a very cold beam.\nThe beam can penetrate a huge amount of enemies at once as well as being able to pass through terrain.\nNot even the Ice Hydra can be compared to this thing.");
			}
			else
			{
				Tooltip.SetDefault("Fires a very cold beam.\nThe beam can penetrate a huge amount of enemies at once as well as being able to pass through terrain.");
			}
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults() 
		{
			if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod))
			{
				Item.damage = 666;
				Item.useTime = 16;
				Item.useAnimation = 16;
			}
			else
			{
				Item.damage = 222;
				Item.useTime = 8;
				Item.useAnimation = 8;
			}

			Item.width = 144;
			Item.mana = 5;
			Item.height = 144;
			Item.scale = 1f;
			Item.crit = 75;
			Item.rare = ItemRarityID.Red;
			Item.useStyle = ItemUseStyleID.Shoot; 
			Item.autoReuse = true;
			Item.UseSound = new SoundStyle($"{nameof(RandomContentModIII)}/Assets/Sounds/Items/IceLaser")
			{
				Volume = 0.9f,
				PitchVariance = 0.2f,
				MaxInstances = 3,
			};
			Item.DamageType = DamageClass.Magic; 
			Item.knockBack = 5f;
			Item.noMelee = true;
			Item.value = 4000000;
			Item.shoot = ModContent.ProjectileType<IceLaser>();
			Item.shootSpeed = 16f;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			// This code shows using Color.Lerp,  Main.GameUpdateCount, and the modulo operator (%) to do a neat effect cycling between 4 custom colors.
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
				.AddIngredient(ItemID.SnowballCannon)
				.AddIngredient(ItemID.IceFeather, 10)
				.AddIngredient(ItemID.IceBlock, 150)
				.AddIngredient(ItemID.FrostCore, 2)
				.AddIngredient(ItemID.FrozenTurtleShell)
				.AddIngredient(ItemID.HallowedBar, 25)
				.AddIngredient(ItemID.FragmentStardust, 75)
				.AddIngredient(ItemID.FragmentNebula, 75)
				.AddIngredient(ItemID.LunarBar, 75)
				.AddIngredient(ItemID.SnowBlock, 100)
				.AddIngredient(ItemID.FlinxFur, 25)
				.AddIngredient(ItemID.ShadowbeamStaff)
				.AddIngredient<Items.Placeable.CompressedIce>(25)
				.AddIngredient<Items.Placeable.StarhoodBar>(50)
				.AddIngredient(ItemID.SoulofFright, 10)
				.AddIngredient(ItemID.SoulofMight, 10)
				.AddIngredient(ItemID.SoulofSight, 10)
				.AddTile(TileID.IceMachine)
				.Register();
		}
	}
}
