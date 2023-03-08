using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace RandomContentModIII.Content.Projectiles
{
	public class IceLaser : ModProjectile
	{
		public override void SetDefaults() 
		{
			Projectile.CloneDefaults(ProjectileID.ShadowBeamFriendly);
			AIType = ProjectileID.ShadowBeamFriendly;
			Projectile.penetrate = 1000;
			Projectile.tileCollide = false;
			//yes, this was 100% very hard to figure out
		}
	}
}
