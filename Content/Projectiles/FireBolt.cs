//using ExampleMod.Content.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomContentModIII.Content.Projectiles
{
	// This Example show how to implement simple homing projectile
	// Can be tested with ExampleCustomAmmoGun
	public class FireBolt : ModProjectile
	{
		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Fire Bolt");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20; // The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
			//ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
		}

		// Setting the default parameters of the projectile
		// You can check most of Fields and Properties here https://github.com/tModLoader/tModLoader/wiki/Projectile-Class-Documentation
		public override void SetDefaults() 
		{
			Projectile.CloneDefaults(ProjectileID.ChlorophyteBullet);
			AIType = ProjectileID.ChlorophyteBullet;
			Projectile.width = 8; // The width of projectile hitbox
			Projectile.height = 8; // The height of projectile hitbox
			Projectile.scale = 2f;
		}

		public override void AI()
        {
            //Projectile appears at 4 ticks
            //if(Projectile.ai[0] > 13.3f)
            {
                for(int i = 0; i < 8; i++)
                {
                    int DustID = Dust.NewDust(Projectile.position, Projectile.width + 2, Projectile.height + 2, 6, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 3f);
                    Main.dust[DustID].noGravity = true;
                    Main.dust[DustID].scale *= 1f;
                }
            }
            Projectile.ai[0] += 1f;
        }
	}
}