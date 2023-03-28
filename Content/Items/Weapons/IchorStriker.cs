using RandomContentModIII.Common.Players;
using RandomContentModIII.Content.Projectiles;
using RandomContentModIII.Content.DamageClasses;
using RandomContentModIII.Content.Items;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using RandomContentModIII.Content.Items.Other;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class StaffofIchor : ModItem
	{
		private int SoulflowCost; // Add our custom resource cost

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Staff of Ichor");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Shoots an ichor shower which decreases enemy defense.");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults() {
			Item.damage = 75;
			Item.DamageType = ModContent.GetInstance<SoulflowDamageClass>();
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 15);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item21;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.GoldenShowerFriendly;
			Item.shootSpeed = 20;
			Item.crit = 32;
			Item.scale = 1f;
			SoulflowCost = 5; // Set our custom resource cost to 5
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) 
		{
			tooltips.Add(new TooltipLine(Mod, "SoulflowCost", $"Uses {SoulflowCost} Soulflow\n[c/7914c7:-Soulflow item-]"));
		}

		// Make sure you can't use the item if you don't have enough resource
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

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient<IchoryStriker>(1)
				.AddIngredient(ItemID.Ichor, 75)
				.AddIngredient(ItemID.TissueSample, 50)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}