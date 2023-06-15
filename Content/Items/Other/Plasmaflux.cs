using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace RandomContentModIII.Content.Items.Other
{
	public class Plasmaflux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plasma Infusion");
			Tooltip.SetDefault("Infuses you with plasma for 2 minutes increasing your life regen and defense.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 28;
			Item.useStyle = 4;
			Item.useAnimation = 90;
			Item.useTime = 90;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item92;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.rare = 13;
			Item.value = Item.buyPrice(gold: 100);
			Item.buffType = ModContent.BuffType<Buffs.PlasmafluxBuff>(); // Specify an existing buff to be applied when used.
			Item.buffTime = 7200; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<PlasmaNucleus>()
				.AddIngredient(ItemID.Ectoplasm, 50)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

	}
}