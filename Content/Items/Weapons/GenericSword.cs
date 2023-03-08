using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class GenericSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("GenericSword");
			//Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			Item.damage = 150;
			Item.DamageType = DamageClass.Melee;
			Item.crit = 100;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useTurn = true;
			Item.scale = 15;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 100000;
			Item.rare = 12;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}