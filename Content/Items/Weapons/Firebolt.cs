using RandomContentModIII.Common.Players;
using RandomContentModIII.Content.Projectiles;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class Firebolt : ModItem
	{
		private int SoulflowCost; // Add our custom resource cost

		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("A powerful and quick gun which will obliterate anything that's in your way.\nInspired by Soul Knight.'\n[c/7914c7:-Soulflow item-]");
		}

		public override void SetDefaults() {
			Item.damage = 125;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 375;
			Item.height = 148;
			Item.useTime = 3;
			Item.useAnimation = 3;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 15);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item40;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.VortexBeaterRocket;
			Item.shootSpeed = 25;
			Item.crit = 32;
			Item.scale = 0.2f;
			SoulflowCost = 5; // Set our custom resource cost to 5
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) 
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) 
		{
			tooltips.Add(new TooltipLine(Mod, "SoulflowCost", $"Uses {SoulflowCost} Soulflow"));
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
				.AddIngredient(ItemID.Handgun, 1)
				.AddIngredient(ItemID.SDMG, 1)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
