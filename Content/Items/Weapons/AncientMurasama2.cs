using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RandomContentModIII.Content.Projectiles;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class AncientMurasama2 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Murasama");
			Tooltip.SetDefault("There will be blood!");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Arkhalis);
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<AncientMurasamaBlade2>();
			Item.useStyle = 5;
			Item.damage = 666;
			Item.shootSpeed = 1f;
			Item.autoReuse = true;
			Item.value = 500000;
			Item.useTime = 7;
		}
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.FragmentSolar, 250)
				.AddIngredient(ItemID.Zenith)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
