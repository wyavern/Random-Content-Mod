using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RandomContentModIII.Content.Projectiles;
using RandomContentModIII.Content.Items.Placeable;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class Terrasama : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Terra Claymore");
			Tooltip.SetDefault("Terra Blade on top.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.CloneDefaults(ItemID.TerraBlade);
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileID.TerraBeam;
			Item.damage = 100;
			Item.shootSpeed *= 2f;
			Item.autoReuse = true;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.value = 1000000;
			//Item.useStyle = 5;
			Item.channel = true;
		}
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.TerraBlade)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
