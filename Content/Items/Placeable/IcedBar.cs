using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RandomContentModIII.Content.Items.Placeable
{
	public class IcedBar : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 100;
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 500000; /
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.IcedBarBlock>();
			Item.placeStyle = 0;
			Item.material = true;
		}
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.IceBlock, 25)
				.AddIngredient(ItemID.SnowBlock, 10)
				.AddIngredient(ItemID.LunarBar, 1)
				.AddTile(TileID.IceMachine)
				.Register();
		}
	}
}
