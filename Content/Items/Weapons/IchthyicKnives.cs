using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class IchthyicKnives : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("An upgraded verison of the Vampire Knives. Shoots 5 lifestealing knives.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			// Common Properties
			Item.width = 32; // Hitbox width of the item.
			Item.height = 32; // Hitbox height of the item.
			Item.rare = ItemRarityID.Purple;
			Item.value = 250000;// The color that the item's name will be in-game.

			// Use Properties
			Item.useTime = 10; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 10; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Swing; // How you use the item (swinging, holding out, etc.)
			Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
			Item.UseSound = SoundID.Item39; // The sound that this item plays when used.

			// Weapon Properties
			Item.DamageType = DamageClass.Melee; // Sets the damage type to ranged.
			Item.damage = 40; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.knockBack = 2f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.
			Item.noUseGraphic = true;

			// Gun Properties
			Item.shoot = ProjectileID.VampireKnife; // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 25f; // The speed of the projectile (measured in pixels per frame.)
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			const int NumProjectiles = 5; // The humber of projectiles that this gun will shoot.

			for (int i = 0; i < NumProjectiles; i++) {
				// Rotate the velocity randomly by 30 degrees at max.
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(23));

				// Decrease velocity randomly for nicer visuals.
				newVelocity *= 1f - Main.rand.NextFloat(0.3f);

				// Create a projectile.
				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false; // Return false because we don't want tModLoader to shoot projectile
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.VampireKnives, 1)
				.AddIngredient(ItemID.MythrilBar, 50)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
