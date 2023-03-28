using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace RandomContentModIII.Content.Mounts
{
	// This mount is a car with wheels which behaves simillarly to the unicorn mount. The car has 3 baloons attached to the back.
	public class Mount1 : ModMount
	{
		public const float speed = 10f;

		public override void SetStaticDefaults() {
			// Movement
			MountData.jumpHeight = 100; // How high the mount can jump.
			MountData.acceleration = 1f; // The rate at which the mount speeds up.
			MountData.jumpSpeed = speed; // The rate at which the player and mount ascend towards (negative y velocity) the jump height when the jump button is presssed.
			MountData.blockExtraJumps = false; // Determines whether or not you can use a double jump (like cloud in a bottle) while in the mount.
			MountData.constantJump = true; // Allows you to hold the jump button down.
			MountData.heightBoost = 0; // Height between the mount and the ground
			MountData.fallDamage = 0f; // Fall damage multiplier.
			MountData.runSpeed = speed; // The speed of the mount
			MountData.dashSpeed = 0f; // The speed the mount moves when in the state of dashing.
			MountData.flightTimeMax = int.MaxValue; // The amount of time in frames a mount can be in the state of flying.

			// Misc
			MountData.fatigueMax = int.MaxValue;
			MountData.usesHover = true;
			MountData.buff = ModContent.BuffType<Buffs.Mount1Buff>(); // The ID number of the buff assigned to the mount.
			// Frame data and player offsets
			MountData.totalFrames = 4; // Amount of animation frames for the mount
			//MountData.playerYOffsets =  new int[] { 0 };
			MountData.playerYOffsets = Enumerable.Repeat(1, MountData.totalFrames).ToArray(); // Fills an array with values for less repeating code
			MountData.xOffset = 0;
			MountData.yOffset = 20;
			MountData.playerHeadOffset = 0;
			MountData.bodyFrame = 1;
			// Standing
			MountData.standingFrameCount = 4;
			MountData.standingFrameDelay = 12;
			MountData.standingFrameStart = 0;
			// Running
			MountData.runningFrameCount = 4;
			MountData.runningFrameDelay = 12;
			MountData.runningFrameStart = 0;
			// Flying
			MountData.flyingFrameCount = 4;
			MountData.flyingFrameDelay = 0;
			MountData.flyingFrameStart = 0;
			// In-air
			MountData.inAirFrameCount = 4;
			MountData.inAirFrameDelay = 12;
			MountData.inAirFrameStart = 0;
			// Idle
			MountData.idleFrameCount = 4;
			MountData.idleFrameDelay = 12;
			MountData.idleFrameStart = 0;
			MountData.idleFrameLoop = true;
			// Swim
			MountData.swimFrameCount = MountData.inAirFrameCount;
			MountData.swimFrameDelay = MountData.inAirFrameDelay;
			MountData.swimFrameStart = MountData.inAirFrameStart;

			if (!Main.dedServ) {
				MountData.textureWidth = MountData.backTexture.Width();
				MountData.textureHeight = MountData.backTexture.Height();
			}
		}
	}
}