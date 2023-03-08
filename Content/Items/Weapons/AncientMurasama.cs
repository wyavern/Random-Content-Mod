using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RandomContentModIII.Content.Projectiles;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class AncientMurasama : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Murasama");
			Tooltip.SetDefault("There will be blood!");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.CloneDefaults(ItemID.Arkhalis);
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<AncientMurasamaBlade>();
			Item.damage = 666;
			Item.shootSpeed *= 1f;
			Item.autoReuse = true;
			Item.useTime = 7;
			Item.value = 100000;
			Item.useStyle = 5;
			Item.channel = true;
		}
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.FragmentSolar, 50)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
