using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace RandomContentModIII.Common.Players
{
	public class SoulflowPlayer : ModPlayer
	{
		public int SoulflowCurrent;
		public const int DefaultSoulflowMax = 200; 
		public int SoulflowMax;
		public int SoulflowMax2;
		public float SoulflowRegenRate; 
		internal int SoulflowRegenTimer = 0; 
		public static readonly Color HealSoulflow = new(187, 91, 201); 

		public override void Initialize() 
		{
			SoulflowMax = DefaultSoulflowMax;
		}

		public override void ResetEffects() 
		{
			ResetVariables();
		}

		public override void UpdateDead() 
		{
			ResetVariables();
		}

		private void ResetVariables() 
		{
			SoulflowRegenRate = 5f;
			SoulflowMax2 = SoulflowMax;
		}

		public override void PostUpdateMiscEffects() 
		{
			UpdateResource();
		}

		private void UpdateResource() 
		{
			SoulflowRegenTimer++;

			if (SoulflowRegenTimer > 160 / SoulflowRegenRate) {
				SoulflowCurrent += 1;
				SoulflowRegenTimer = 0;
			}

			SoulflowCurrent = Utils.Clamp(SoulflowCurrent, 0, SoulflowMax2);
		}
	}
}