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
	public class BloodyRawSoulflowHood : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The bloody tier of soulflow armor.\n[c/7914c7:-Soulflow item-]");

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
			return body.type == ModContent.ItemType<BloodyRawSoulflowBreastplate>() && legs.type == ModContent.ItemType<BloodyRawSoulflowLeggings>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "reduces maximum soulflow by 50 but increases soulflow regeneration and damage.";  // This is the setbonus tooltip
			var modPlayer = player.GetModPlayer<SoulflowPlayer>(); 
			modPlayer.SoulflowRegenRate *= 2.5f;
			modPlayer.SoulflowMax2 -= 50;
			player.GetDamage<SoulflowDamageClass>() *= 1.25f;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient<BloodyRawSoulflow>(15)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}