using Terraria;
using RandomContentModIII.Content.Items.Other;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using RandomContentModIII.Common.Players;
using RandomContentModIII.Content.DamageClasses;

namespace RandomContentModIII.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CorruptRawSoulflowHood : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The corrupt soulflow armor.\n[c/7914c7:-Soulflow item-]");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Orange; // The rarity of the item
			Item.defense = 5; // The amount of defense the item will give when equipped
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<CorruptRawSoulflowBreastplate>() && legs.type == ModContent.ItemType<CorruptRawSoulflowLeggings>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "increases maximum soulflow by 50 and slightly increases soulflow regeneration and damage.";  // This is the setbonus tooltip
			var modPlayer = player.GetModPlayer<SoulflowPlayer>(); 
			modPlayer.SoulflowRegenRate *= 1.15f;
			modPlayer.SoulflowMax2 += 50;
			player.GetDamage<SoulflowDamageClass>() *= 1.15f;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient<CorruptRawSoulflow>(15)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}