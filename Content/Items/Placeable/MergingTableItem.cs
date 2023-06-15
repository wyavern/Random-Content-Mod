using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RandomContentModIII.Content.Items.Other;

namespace RandomContentModIII.Content.Items.Placeable
{
	public class MergingTableItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Merging Table");
			Tooltip.SetDefault("Can merge your items for a stronger variant that will have the stats of both.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.createTile = ModContent.TileType<Tiles.MergingTable>();
			Item.width = 38;
			Item.height = 24;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 15;
			Item.maxStack = 750;
			Item.consumable = true;
			Item.value = 1500;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Extractinator)
				.AddIngredient(ItemID.HellstoneBar ,22)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}