using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using RandomContentModIII.Common.Players;
using RandomContentModIII.Content.Projectiles;
using RandomContentModIII.Content.DamageClasses;
using RandomContentModIII.Content.Items;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;
using RandomContentModIII.Content.Items.Other;


namespace RandomContentModIII.Content.Items.Weapons
{
	public class ToxicChlorophyteStaff : ModItem
	{
		private int SoulflowCost;

		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Shoots a spore cloud or a chlorophyte orb to kill your enemies.");
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.damage = 90;
			Item.width = 62;
			Item.height = 32; 
			Item.scale = 0.75f;
			Item.rare = ItemRarityID.Lime;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item69;
			Item.DamageType = ModContent.GetInstance<SoulflowDamageClass>();
			Item.knockBack = 5f; 
			Item.noMelee = true; 
			Item.shoot = ProjectileID.ChlorophyteOrb; 
			Item.shootSpeed = 16f; 
			SoulflowCost = 10;
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
				.AddIngredient<Soulflow>(10)
				.AddIngredient(ItemID.ChlorophyteBar, 12)
				.AddTile<Tiles.SoulflowBench>()
				.Register();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) 
		{
			if (Main.rand.NextBool(3)) {
				type = (ProjectileID.SporeCloud);
			}
		}
	}
}