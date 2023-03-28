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
	public class SoulflowBoulderStaff : ModItem
	{
		private int SoulflowCost; // Add our custom resource cost

		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Shoots 2 earth boulders which demolish your enemies.");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults() {
			Item.damage = 105;
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
			Item.shoot = ProjectileID.BoulderStaffOfEarth;
			Item.shootSpeed = 20;
			Item.crit = 40;
			Item.scale = 1f;
			Item.mana = 0;
			SoulflowCost = 20; // Set our custom resource cost to 5
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float numberProjectiles = 2 + Main.rand.Next(0); 
			float rotation = MathHelper.ToRadians(5);

			position += Vector2.Normalize(velocity) * 45f;

			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f; 
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}

			return false; 
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
				.AddIngredient(ItemID.StaffofEarth, 1)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}