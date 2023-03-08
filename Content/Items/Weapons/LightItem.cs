using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RandomContentModIII.Content.Projectiles;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class LightItem : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Light Item");
			Tooltip.SetDefault("'Light it all up, mate!'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.CloneDefaults(ItemID.Arkhalis);
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<LightItemBlade>();
			Item.damage = 0;
			Item.shootSpeed *= 1f;
			Item.autoReuse = true;
			Item.useTime = 7;
		}
		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient(ItemID.Torch, 100)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
