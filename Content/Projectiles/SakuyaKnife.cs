using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomContentModIII.Content.Projectiles
{
	// This file showcases the concept of piercing.
	// The code of the item that spawns it is located at the bottom.

	// NPC.immune determines if an npc can be hit by a item or projectile owned by a particular player (it is an array, each slot corresponds to different players (whoAmI))
	// NPC.immune is decremented towards 0 every update
	// Melee items set NPC.immune to player.itemAnimation, which starts at item.useAnimation and decrements towards 0
	// Projectiles, however, provide mechanisms for custom immunity.
	// 1. penetrate == 1: A projectile with penetrate set to 1 in SetDefaults will hit regardless of the npc's immunity counters (The penetrate from SetDefaults is remembered in maxPenetrate)
	//	Ex: Wooden Arrow.
	// 2. No code and penetrate > 1 or -1: npc.immune[owner] will be set to 10.
	// 	The NPC will be hit if not immune and will become immune to all damage for 10 ticks
	// 	Ex: Unholy Arrow
	// 3. Override OnHitNPC: If not immune, when it hits it manually set an immune other than 10
	// 	Ex: Arkhalis: Sets it to 5
	// 	Ex: Sharknado Minion: Sets to 20
	// 	Video: https://gfycat.com/DisloyalImprobableHoatzin Notice how Sharknado minion hits prevent Arhalis hits for a brief moment.
	// 4. Projectile.usesIDStaticNPCImmunity and Projectile.idStaticNPCHitCooldown: Specifies that a type of projectile has a shared immunity timer for each npc.
	// 	Use this if you want other projectiles a chance to damage, but don't want the same projectile type to hit an npc rapidly.
	// 	Ex: Ghastly Glaive is the only one who uses this.
	// 5. Projectile.usesLocalNPCImmunity and Projectile.localNPCHitCooldown: Specifies the projectile manages it's own immunity timers for each npc
	// 	Use this if you want the multiple projectiles of the same type to have a chance to attack rapidly, but don't want a single projectile to hit rapidly. A -1 value prevents the same projectile from ever hitting the npc again.
	// 	Ex: Lightning Aura sentries use this. (localNPCHitCooldown = 3, but other code controls how fast the projectile itself hits)
	// 		Overlapping Auras all have a chance to hit after each other even though they share the same ID.
	// Try the above by uncommenting out the respective bits of code in the projectile below.


	public class SakuyaKnife : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sakuya Knife"); // The name of the projectile(it can be appeared in chat)
		}

		public override void SetDefaults() 
		{
			Projectile.alpha = 0;
			Projectile.width = 49; // The width of projectile hitbox
			Projectile.height = 22; // The height of projectile hitbox
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.DamageType = DamageClass.Magic; // Is the projectile shoot by a ranged weapon?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.tileCollide = true; // Can the projectile collide with tiles?
			Projectile.timeLeft = 600; // Each update timeLeft is decreased by 1. Once timeLeft hits 0, the Projectile will naturally despawn. (60 ticks = 1 second)
		}
		public override void AI()
		{
			Projectile.direction = Projectile.spriteDirection = (Projectile.velocity.X > 0f) ? 1 : -1;

				Projectile.rotation = Projectile.velocity.ToRotation();
				// Since our sprite has an orientation, we need to adjust rotation to compensate for the draw flipping
				if (Projectile.spriteDirection == -1) {
					Projectile.rotation += MathHelper.Pi;
				}
		}
		// See comments at the beginning of the class
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) 
		{
			  Main.player[Projectile.owner].statLife += 5;
		}
	}
}
