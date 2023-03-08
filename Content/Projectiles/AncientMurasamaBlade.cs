using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomContentModIII.Content.Projectiles
	{
		class AncientMurasamaBlade : ModProjectile
		{
			public override void SetStaticDefaults()
			{
				Main.projFrames[Projectile.type] = 28;
			}

			public override void SetDefaults()
			{
				Projectile.CloneDefaults(ProjectileID.Arkhalis);
				AIType = ProjectileID.Arkhalis;
				Projectile.penetrate = -1;
				Projectile.scale = 1.5f;
			}



			public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
			{
				//3a: target.immune[projectile.owner] = 20;
				//3b: target.immune[projectile.owner] = 5;
			}

			public override Color? GetAlpha(Color lightColor)
			{
				//return Color.White;
				return new Color(255, 0, 0, 0) * (1f - (float)Projectile.alpha / 255f);
			}

			public override void AI()
			{
				// Slow down
				Projectile.velocity *= 0.98f;
				// Loop through the 4 animation frames, spending 5 ticks on each.
				if (++Projectile.frameCounter >= 10)
				{
					Projectile.frameCounter = 1;
					if (++Projectile.frame >= 28)
					{
						Projectile.frame = 0;
					}
				}

				Projectile.direction = (Projectile.spriteDirection = ((Projectile.velocity.X > 0f) ? 1 : -1));
				Projectile.rotation = Projectile.velocity.ToRotation();
				if (Projectile.velocity.Y > 16f)
				{
					Projectile.velocity.Y = 16f;
				}
				// Since our sprite has an orientation, we need to adjust rotation to compensate for the draw flipping.
				if (Projectile.spriteDirection == -1)
				Projectile.rotation += MathHelper.Pi;
			}

			// Some advanced drawing because the texture image isn't centered or symetrical.
			public override bool PreDraw(ref Color lightColor)
			{
				SpriteEffects spriteEffects = SpriteEffects.None;
				if (Projectile.spriteDirection == -1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int startY = frameHeight * Projectile.frame;
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
			Vector2 origin = sourceRectangle.Size() / 2f;
			origin.X = (float)((Projectile.spriteDirection == 1) ? (sourceRectangle.Width - 40) : 40);

			Color drawColor = Projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw(texture,
			Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
			sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0f);

			return false;
			}
		}
	}