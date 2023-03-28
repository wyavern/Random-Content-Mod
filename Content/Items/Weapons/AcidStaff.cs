using RandomContentModIII.Common.Players;
using RandomContentModIII.Content.Projectiles;
using RandomContentModIII.Content.DamageClasses;
using RandomContentModIII.Content.Items;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using RandomContentModIII.Content.Items.Other;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class AcidStaff : ModItem
	{
		private int SoulflowCost; // Add our custom resource cost

		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Shoots 2 cursed flames."); //\n[c/7914c7:-Soulflow item-]");
		}

		public override void SetDefaults() {
			Item.damage = 15;
			Item.DamageType = ModContent.GetInstance<SoulflowDamageClass>();
			Item.width = 34;
			Item.height = 84;
			Item.useTime = 29;
			Item.useAnimation = 29;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 15);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item117;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.CursedFlameFriendly;
			Item.shootSpeed = 20;
			Item.crit = 32;
			Item.scale = 1;
			Item.mana = 0;
			SoulflowCost = 9; // Set our custom resource cost to 5
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float numberProjectiles = 2 + Main.rand.Next(0); 
			float rotation = MathHelper.ToRadians(15);

			position += Vector2.Normalize(velocity) * 20f;

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
				.AddIngredient<CorruptRawSoulflow>(75)
				.AddIngredient(ItemID.DemoniteBar, 25)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}