using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;

namespace RandomContentModIII.Content.Items.Placeable
{
	public class CompressedIce : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}

		public override void SetDefaults() 
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.material = true;
		}

		public override void AddRecipes() {
			CreateRecipe(1)
				.AddIngredient(ItemID.IceBlock, 20)
				.AddTile(TileID.IceMachine)
				.Register();

			//CreateRecipe()
			//	.AddIngredient<CompressedIceWall>(4)
			//	.AddTile(TileID.Workbench)
			//	.Register();

			//CreateRecipe()
			//	.AddIngredient<CompressedIcePlatform>(2)
			//	.AddTile(TileID.Workbench)
			//	.Register();
		}
	}
}
