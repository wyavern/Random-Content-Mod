using Terraria;
using RandomContentModIII.Content.Items.Other;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using RandomContentModIII.Common.Players;
using RandomContentModIII.Content.Items;
using RandomContentModIII.Content.DamageClasses;

namespace RandomContentModIII.Content.Items.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Body)]
	public class RawSoulflowBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Raw Soulflow Breastplate");
			Tooltip.SetDefault("The lowest tier of soulflow armor."
				+ "\nImmunity to 'On Fire!'"
				+ "\n+60 max soulflow and slightly increased soulflow regeneration."
				+ "\n[c/7914c7:-Soulflow item-]");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Blue; // The rarity of the item
			Item.defense = 6; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) 
		{
			player.buffImmune[BuffID.OnFire] = true;
			var modPlayer = player.GetModPlayer<SoulflowPlayer>();
			modPlayer.SoulflowMax2 += 60;
			//modPlayer.SoulflowRegenRate *= 1.5f;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<RawSoulflow>(20)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}