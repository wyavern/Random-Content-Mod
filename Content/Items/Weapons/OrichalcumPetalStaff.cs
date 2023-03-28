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
	public class OrichalcumPetalStaff : ModItem
	{
		private int SoulflowCost; // Add our custom resource cost

		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Shoots a flower petal which will pierce and kill your enemies.");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults() {
			Item.damage = 55;
			Item.DamageType = ModContent.GetInstance<SoulflowDamageClass>();
			Item.width = 44;
			Item.height = 48;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 100);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item69;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.FlowerPetal;
			Item.shootSpeed = 25f;
			Item.crit = 40;
			Item.scale = 1f;
			Item.mana = 0;
			SoulflowCost = 10; // Set our custom resource cost to 5
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
				.AddIngredient<Soulflow>(50)
				.AddIngredient(ItemID.OrichalcumBar, 15)
				.AddTile(TileID.Anvils)
				.Register();
			CreateRecipe()
				.AddIngredient<Soulflow>(50)
				.AddIngredient(ItemID.MythrilBar, 15)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}