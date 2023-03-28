using Terraria;
using RandomContentModIII.Content.Items.Other;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using RandomContentModIII.Common.Players;
using RandomContentModIII.Content.DamageClasses;

namespace RandomContentModIII.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class RefinedSoulflowGreaves : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("The highest tier of soulflow armor."
				+ "\n105% increased movement speed"
				+ "\nHighly increased soulflow regeneration rate and damage."
				+ "\n+200 max soulflow."
				+ "\n[c/7914c7:-Soulflow item-]");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = Item.sellPrice(gold: 140); 
			Item.rare = ItemRarityID.Purple;
			Item.defense = 20; 
		}

		public override void UpdateEquip(Player player) 
		{
			player.moveSpeed += 1.05f;
			var modPlayer = player.GetModPlayer<SoulflowPlayer>(); 
			modPlayer.SoulflowRegenRate *= 1.5f; 
			modPlayer.SoulflowMax2 += 200;
			player.GetDamage<SoulflowDamageClass>() *= 1.05f;
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