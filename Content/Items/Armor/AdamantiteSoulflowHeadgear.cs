using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using RandomContentModIII.Common.Players;
using RandomContentModIII.Content.DamageClasses;
using RandomContentModIII.Content.Items.Other;

namespace RandomContentModIII.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class AdamantiteSoulflowHeadgear : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("[c/7914c7:-Soulflow item-]");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.CloneDefaults(ItemID.AdamantiteHelmet);
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.LightRed; // The rarity of the item
			Item.defense = 8; // The amount of defense the item will give when equipped
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == (ItemID.AdamantiteBreastplate) && legs.type == (ItemID.AdamantiteLeggings);
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "increases maximum soulflow by 150, as well as slightly increasing soulflow regeneration and damage.";  // This is the setbonus tooltip
			var modPlayer = player.GetModPlayer<SoulflowPlayer>(); 
			modPlayer.SoulflowRegenRate *= 1.55f;
			modPlayer.SoulflowMax2 += 150;
			player.GetDamage<SoulflowDamageClass>() *= 1.35f;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient<Soulflow>(20)
				.AddIngredient(ItemID.AdamantiteBar, 12)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}