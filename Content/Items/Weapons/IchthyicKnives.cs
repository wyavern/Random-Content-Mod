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
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("An upgraded verison of the Vampire Knives. Shoots 5 lifestealing knives.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.width = 32; 
			Item.height = 32; 
			Item.rare = ItemRarityID.Purple;
			Item.value = 250000;
			Item.useTime = 10; 
			Item.useAnimation = 10; 
			Item.useStyle = ItemUseStyleID.Swing;
			Item.autoReuse = true; 
			Item.UseSound = SoundID.Item39;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 40;
			Item.knockBack = 2f;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.shoot = ProjectileID.VampireKnife;
			Item.shootSpeed = 25f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) 
		{
			const int NumProjectiles = 5;

			for (int i = 0; i < NumProjectiles; i++) 
			{
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(23));
				newVelocity *= 1f - Main.rand.NextFloat(0.3f);
				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient(ItemID.VampireKnives, 1)
				.AddIngredient(ItemID.MythrilBar, 50)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
