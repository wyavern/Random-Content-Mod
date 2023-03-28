using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RandomContentModIII.Content.Items.Other;

namespace RandomContentModIII.Content.Items.Placeable
{
	public class SoulflowBenchItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Soulflow Bench");
			Tooltip.SetDefault("Used for high tier soulflow crafting.\n[c/7914c7:-Soulflow item-]");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.createTile = ModContent.TileType<Tiles.SoulflowBench>();
			Item.width = 28;
			Item.height = 14;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 15;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.value = 150;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.WorkBench)
				.AddIngredient<Soulflow>(22)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}