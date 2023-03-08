using RandomContentModIII.Content.Projectiles;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using RandomContentModIII.Content.Rarities;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class DestructiveArray : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Intergalactic Destruction Array");
			Tooltip.SetDefault("'Don't expect a painless death.'\nShoots a deadly galactic [c/FF00AA:Fireball] that ignores enemy's Immunity Frames.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//Item.staff[Item.type] = true;
		}

		public override void SetDefaults() 
		{
			Item.damage = 200;
			Item.DamageType = DamageClass.Magic; 
			Item.width = 110; //make sure this is acurate or bald
			Item.height = 44; // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 5; 
			Item.noMelee = true; 
			Item.knockBack = 6;
			Item.value = 100000;
			Item.rare = ModContent.RarityType<ModRarity1>();
			Item.UseSound = SoundID.Item72;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<GalacticDeathRay>();
			Item.shootSpeed = 14;
			Item.crit = 57;
			Item.mana = 27;
			Item.channel = true;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.LunarBar, 100)
				.AddIngredient(ItemID.FragmentNebula, 25)
				.AddIngredient(ItemID.FragmentSolar, 25)
				.AddIngredient(ItemID.FragmentVortex, 25)
				.AddIngredient(ItemID.FragmentStardust, 25)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
		//position adjustment
		public override Vector2? HoldoutOffset() {
			return new Vector2(-2f, -2f);
		}
	}
}
