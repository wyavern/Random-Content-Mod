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
	[AutoloadEquip(EquipType.Body)]
	public class RefinedSoulflowBreastplate : ModItem
	{
		public override void SetStaticDefaults() 
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("The best tier of soulflow armor."
				+ "\nImmunity to most debuffs"
				+ "\n+250 max soulflow and drastically increased soulflow regeneration."
				+ "\n[c/7914c7:-Soulflow item-]");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.width = 34; 
			Item.height = 22; 
			Item.value = Item.sellPrice(gold: 170); 
			Item.rare = ItemRarityID.Purple;
			Item.defense = 18;
		}

		public override void UpdateEquip(Player player) 
		{
			player.buffImmune[BuffID.Poisoned] = true;
			player.buffImmune[BuffID.Darkness] = true;
			player.buffImmune[BuffID.Cursed] = true;
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Bleeding] = true;
			player.buffImmune[BuffID.Confused] = true;
			player.buffImmune[BuffID.Slow] = true;
			player.buffImmune[BuffID.Weak] = true;
			player.buffImmune[BuffID.Silenced] = true;
			player.buffImmune[BuffID.BrokenArmor] = true;
			player.buffImmune[BuffID.Horrified] = true;
			player.buffImmune[BuffID.CursedInferno] = true;
			player.buffImmune[BuffID.Frostburn] = true;
			player.buffImmune[BuffID.Chilled] = true;
			player.buffImmune[BuffID.Frozen] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.buffImmune[BuffID.Ichor] = true;
			player.buffImmune[BuffID.Venom] = true;
			player.buffImmune[BuffID.Blackout] = true;
			player.buffImmune[BuffID.ChaosState] = true;
			player.buffImmune[BuffID.Electrified] = true;
			player.buffImmune[BuffID.Webbed] = true;
			player.buffImmune[BuffID.ShadowFlame] = true;
			player.buffImmune[BuffID.Stoned] = true;
			player.buffImmune[BuffID.Dazed] = true;
			player.buffImmune[BuffID.Obstructed] = true;
			player.buffImmune[BuffID.VortexDebuff] = true;
			player.buffImmune[BuffID.OgreSpit] = true;
			player.buffImmune[BuffID.WitheredWeapon] = true;
			player.buffImmune[BuffID.WitheredArmor] = true;
			player.buffImmune[BuffID.Midas] = true;
			var modPlayer = player.GetModPlayer<SoulflowPlayer>();
			//I still didn't find a way to make this more compact, so  you will have to deal with this amount of lines just for the immunities.
			modPlayer.SoulflowMax2 += 250;
			modPlayer.SoulflowRegenRate *= 5f;
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