using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using RandomContentModIII.Content.Items.Other;

namespace RandomContentModIII.Content.Items.Other
{
	public class WingedRemote : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Winged Remote");
			Tooltip.SetDefault("Summons a pair of wings that can fly infinitely.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.HoldUp; // how the player's arm moves when using the item
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item79; // What sound should play when using the item
			Item.noMelee = true; // this item doesn't do any melee damage
			Item.mountType = ModContent.MountType<Content.Mounts.Mount1>();
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<Soulflow>(25)
				.AddTile<Tiles.SoulflowBench>()
				.Register();
		}
	}
}