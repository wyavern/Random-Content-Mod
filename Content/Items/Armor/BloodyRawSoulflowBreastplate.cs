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
	public class BloodyRawSoulflowBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Bloody Raw Soulflow Breastplate");
			Tooltip.SetDefault("The bloody tier of soulflow armor."
				+ "\nImmunity to 'On Fire!'"
				+ "\n+10 max soulflow and slightly increased soulflow regeneration."
				+ "\n[c/7914c7:-Soulflow item-]");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Orange; // The rarity of the item
			Item.defense = 8; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) 
		{
			player.buffImmune[BuffID.OnFire] = true;
			var modPlayer = player.GetModPlayer<SoulflowPlayer>();
			modPlayer.SoulflowMax2 += 10;
			modPlayer.SoulflowRegenRate *= 1.05f;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<BloodyRawSoulflow>(20)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}