using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ReLogic.Localization.IME;
using Terraria.Localization;

namespace RandomContentModIII.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class LunarWings : ModItem
	{

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Lunar Wings");
			Tooltip.SetDefault("Want the Moon? Just put these on and fly to it!");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(3600, 11f, 3.5f);
		}

		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 20;
			Item.value = 10000;
			Item.rare = ItemRarityID.Red;
			Item.accessory = true;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.85f; // 0.85f is usual
			ascentWhenRising = 0.15f; // 0.15f is the usual
			maxCanAscendMultiplier = 1f; //1 is the usual
			maxAscentMultiplier = 3f; //3 is the usual
			constantAscend = 0.335f; //0.135 is the usual
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.LunarBar, 100)
				.AddIngredient(ItemID.SoulofFlight, 20)
				.AddTile(TileID.MythrilAnvil)
				.SortBefore(Main.recipe.First(recipe => recipe.createItem.wingSlot != -1)) // Places this recipe before any wing so every wing stays together in the crafting menu.
				.Register();
		}
	}
}