using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Net;
using Terraria.GameContent.NetModules;
using Terraria.GameContent.Creative;
using RandomContentModIII.Content.Items.Other;

namespace RandomContentModIII.Content.Items.Other
{
	public class Soulflow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The second best tier of soulflow.\nUsed in soulflow crafting.\n[c/7914c7:-Soulflow item-]"); // The (English) text shown below your item's name
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100; // How many items are needed in order to research duplication of this item in Journey mode. See https://terraria.gamepedia.com/Journey_Mode/Research_list for a list of commonly used research amounts depending on item type.
		}

		public override void SetDefaults() {
			Item.width = 22; // The item texture's width
			Item.height = 22; // The item texture's height

			Item.maxStack = 999; // The item's max stack value
			Item.value = Item.buyPrice(silver: 200); // The value of the item in copper coins. Item.buyPrice & Item.sellPrice are helper methods that returns costs in copper coins based on platinum/gold/silver/copper arguments provided to it.
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe(2)
				.AddIngredient<RawSoulflow>(10)
				.AddIngredient(ItemID.SoulofLight, 5)
				.AddIngredient(ItemID.SoulofNight, 10)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}