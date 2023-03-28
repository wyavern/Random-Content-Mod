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
	public class ChlorophyteSoulflowHeadgear : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("[c/7914c7:-Soulflow item-]");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.CloneDefaults(ItemID.ChlorophyteMask);
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Lime; // The rarity of the item
			Item.defense = 9; // The amount of defense the item will give when equipped
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == (ItemID.ChlorophytePlateMail) && legs.type == (ItemID.ChlorophyteGreaves);
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "increases maximum soulflow by 250, soulflow regeneration and damage.\nSummons a powerful leaf crystal to shoot at nearby enemies";  // This is the setbonus tooltip
			var modPlayer = player.GetModPlayer<SoulflowPlayer>(); 
			modPlayer.SoulflowRegenRate *= 3.5f;
			modPlayer.SoulflowMax2 += 250;
			player.GetDamage<SoulflowDamageClass>() *= 1.45f;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient<Soulflow>(20)
				.AddIngredient(ItemID.ChlorophyteBar, 12)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}