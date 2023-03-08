using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Localization;
using Terraria.ModLoader;

namespace RandomContentModIII.Content.Items.Consumables
{
	public class HealingCrystal : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Healing Crystal");
			Tooltip.SetDefault("Used once per frame");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useAnimation = 0;
			Item.useTime = 0;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item93;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(gold: 1);

			Item.healLife = 5; 
			Item.potion = false;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.SuperHealingPotion, 10)
				.AddTile(TileID.Bottles)
				.Register();
		}
	}
}