using RandomContentModIII.Common.Players;
using RandomContentModIII.Content.Projectiles;
using RandomContentModIII.Content.DamageClasses;
using RandomContentModIII.Content.Items.Other;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class VortexShooter : ModItem
	{
		private int SoulflowCost; // Add our custom resource cost

		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("A powerful and quick weapon which will obliterate anything that's in your way."); //\n[c/7914c7:-Soulflow item-]
		}

		public override void SetDefaults() {
			Item.damage = 50;
			Item.DamageType = ModContent.GetInstance<SoulflowDamageClass>();
			Item.width = 375;
			Item.height = 148;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 15);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item40;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.VortexBeaterRocket;
			Item.shootSpeed = 25;
			Item.crit = 10;
			Item.scale = 0.17f;
			SoulflowCost = 2; // Set our custom resource cost to 5
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
				.AddIngredient<Soulflow>(100)
				.AddIngredient(ItemID.FragmentVortex, 25)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}