using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RandomContentModIII.Content.Projectiles;

namespace RandomContentModIII.Content.Items.Weapons
{
	/// <summary>
	/// This weapon and its corresponding projectile showcase the CloneDefaults() method, which allows for cloning of other items.
	/// For this example, we shall copy the Meowmere and its projectiles with the CloneDefaults() method, while also changing them slightly.
	/// For a more detailed description of each item field used here, check out <see cref="ExampleSword" />.
	/// </summary>
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
