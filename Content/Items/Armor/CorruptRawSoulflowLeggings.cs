using Terraria;
using RandomContentModIII.Content.Items.Other;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RandomContentModIII.Common.Players;
using RandomContentModIII.Content.DamageClasses;

namespace RandomContentModIII.Content.Items.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Legs)]
	public class CorruptRawSoulflowLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The corrupt soulflow armor."
				+ "\n20% increased movement speed"
				+ "\nSlightly increased soulflow damage."
				+ "\n[c/7914c7:-Soulflow item-]");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Orange; // The rarity of the item
			Item.defense = 6; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.2f;
			var modPlayer = player.GetModPlayer<SoulflowPlayer>();  
			player.GetDamage<SoulflowDamageClass>() *= 1.02f;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<CorruptRawSoulflow>(10)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}