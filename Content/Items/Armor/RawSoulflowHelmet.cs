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
	// Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Head)]
	public class RawSoulflowHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The lowest tier of soulflow armor."
			+ "\n+25 max soulflow."
			+ "\n[c/7914c7:-Soulflow item-]");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;

			// If your head equipment should draw hair while drawn, use one of the following:
			// ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
			// ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
			// ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
			// ArmorIDs.Head.Sets.DrawBackHair[Item.headSlot] = true;
			// ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true; 
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Blue; // The rarity of the item
			Item.defense = 5; // The amount of defense the item will give when equipped
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<RawSoulflowBreastplate>() && legs.type == ModContent.ItemType<RawSoulflowLeggings>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Increases dealt soulflow damage by 50%\nIncreases soulflow by 25% and slightly increases soulflow regeneration rate."; // This is the setbonus tooltip
			var modPlayer = player.GetModPlayer<SoulflowPlayer>();
			modPlayer.SoulflowMax2 += 25; // add 100 to the exampleResourceMax2, which is our max for example resource.
			modPlayer.SoulflowRegenRate *= 1.5f; // multiply our resource regeneration speed by 6.
			player.GetDamage<SoulflowDamageClass>() *= 1.25f;
			
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<RawSoulflow>(15)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}