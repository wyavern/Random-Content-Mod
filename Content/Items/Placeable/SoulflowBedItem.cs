using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RandomContentModIII.Content.Items.Other;

namespace RandomContentModIII.Content.Items.Placeable
{
	public class SoulflowBedItem : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 10;
			Tooltip.SetDefault("[c/7914c7:-Soulflow item-]");
		}

		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 22;
			Item.maxStack = 999;
			Item.value = 50; // The cost of the item in copper coins. (1 = 1 copper, 100 = 1 silver, 1000 = 1 gold, 10000 = 1 platinum)
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.SoulflowBed>(); // The ID of the wall that this item should place when used. ModContent.TileType<T>() method returns an integer ID of the wall provided to it through its generic type argument (the type in angle brackets)..
			Item.placeStyle = 0;
			Item.material = true;
		}
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<RawSoulflow>(25)
				.AddTile(TileID.IceMachine)
				.Register();
		}
	}
}
