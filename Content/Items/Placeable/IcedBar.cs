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
			Item.value = 500000; // The cost of the item in copper coins. (1 = 1 copper, 100 = 1 silver, 1000 = 1 gold, 10000 = 1 platinum)
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.IcedBarBlock>(); // The ID of the wall that this item should place when used. ModContent.TileType<T>() method returns an integer ID of the wall provided to it through its generic type argument (the type in angle brackets)..
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
