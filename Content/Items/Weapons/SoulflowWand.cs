using RandomContentModIII.Content.Projectiles;
using RandomContentModIII.Content.DamageClasses;
using RandomContentModIII.Common.Players;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System.Collections.Generic;
using RandomContentModIII.Content.Items.Other;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class SoulflowWand : ModItem
	{
		private int SoulflowCost;
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Soulflow Wand");
			Tooltip.SetDefault("Shoots a weak soulflow laser.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults() 
		{
			Item.damage = 30;
			Item.DamageType = ModContent.GetInstance<SoulflowDamageClass>(); 
			Item.width = 26; 
			Item.height = 28; 
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = 5; 
			Item.noMelee = true; 
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item117;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SoulflowLaser>();
			Item.shootSpeed = 5;
			Item.crit = 10;
			Item.channel = true;
			SoulflowCost = 6;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) 
		{
			tooltips.Add(new TooltipLine(Mod, "SoulflowCost", $"Uses {SoulflowCost} Soulflow\n[c/7914c7:-Soulflow item-]"));
		}

		public override bool CanUseItem(Player player) 
		{
			var SoulflowPlayer = player.GetModPlayer<SoulflowPlayer>();

			if (SoulflowPlayer.SoulflowCurrent >= SoulflowCost) 
			{
				SoulflowPlayer.SoulflowCurrent -= SoulflowCost;
				return true;
			}

			return false;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<RawSoulflow>(25)
				.AddIngredient(ItemID.WandofSparking)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
