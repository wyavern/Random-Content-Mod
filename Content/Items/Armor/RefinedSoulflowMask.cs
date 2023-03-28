using Terraria;
using RandomContentModIII.Content.Items.Other;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RandomContentModIII.Common.Players;
using RandomContentModIII.Content.DamageClasses;

namespace RandomContentModIII.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RefinedSoulflowMask : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("The highest tier of soulflow armor."
			+ "\n+250 max soulflow and increased soulflow regeneration rate."
			+ "\n[c/7914c7:-Soulflow item-]");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;

			// ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
			// ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
			// ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
			// ArmorIDs.Head.Sets.DrawBackHair[Item.headSlot] = true;
			// ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true; 
		}

		public override void SetDefaults() 
		{
			Item.width = 26;
			Item.height = 32; 
			Item.value = Item.sellPrice(gold: 150);
			Item.rare = ItemRarityID.Purple;
			Item.defense = 15;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ModContent.ItemType<RefinedSoulflowBreastplate>() && legs.type == ModContent.ItemType<RefinedSoulflowGreaves>();
		}

		public override void UpdateEquip(Player player) 
		{
			var modPlayer = player.GetModPlayer<SoulflowPlayer>(); 
			modPlayer.SoulflowRegenRate *= 1.05f; 
			modPlayer.SoulflowMax2 += 250;
		}

		public override void UpdateArmorSet(Player player) 
		{
			player.setBonus = "Increases dealt soulflow damage by 75%.\nIncreases maximum soulflow by 200% and drastically increases soulflow regeneration rate."; // This is the setbonus tooltip
			var modPlayer = player.GetModPlayer<SoulflowPlayer>();
			modPlayer.SoulflowMax2 *= 2; 
			modPlayer.SoulflowRegenRate *= 5f; 
			player.GetDamage<SoulflowDamageClass>() *= 1.75f;
			
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient<RefinedSoulflow>(20)
				.AddIngredient(ItemID.FragmentNebula, 5)
				.AddIngredient(ItemID.FragmentStardust, 5)
				.AddIngredient(ItemID.FragmentVortex, 5)
				.AddIngredient(ItemID.FragmentSolar, 5)
				.AddTile(TileID.LunarCraftingStation)
				.AddTile<Tiles.SoulflowBench>()
				.Register();
		}
	}
}