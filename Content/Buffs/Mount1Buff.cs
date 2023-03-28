using Terraria;
using Terraria.ModLoader;

namespace RandomContentModIII.Content.Buffs
{
	public class Mount1Buff : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Flying Platform");
			Description.SetDefault("You've been blessed by a platform that can fly infinitely and float.");
			Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
		}

		public override void Update(Player player, ref int buffIndex) {
			player.mount.SetMount(ModContent.MountType<Mounts.Mount1>(), player);
			player.buffTime[buffIndex] = 10; // reset buff time
		}
	}
}