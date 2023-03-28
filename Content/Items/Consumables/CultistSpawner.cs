using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RandomContentModIII.Content.Items.Consumables
{
	// This is the Item used to summon a boss, in this case the vanilla Plantera boss.
	public class CultistSpawner : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Myseterious Tablet");
			Tooltip.SetDefault("Summons Lunatic Cultist"
			+ "\nToo lazy to wait until the next day?"
			+ "\nJust use this."
			+ "\nCan't be used before Golem has been defeated.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
			ItemID.Sets.SortingPriorityBossSpawns[Type] = 12; // This helps sort inventory know that this is a boss summoning Item.

			// This is set to true for all NPCs that can be summoned via an Item (calling NPC.SpawnOnPlayer). If this is for a modded boss,
			// write this in the bosses file instead
			NPCID.Sets.MPAllowedEnemies[NPCID.CultistBoss] = false;
		}

		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 42;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = ItemRarityID.Red;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
		}

		public override bool CanUseItem(Player player) {
			// If you decide to use the below UseItem code, you have to include !NPC.AnyNPCs(id), as this is also the check the server does when receiving MessageID.SpawnBoss
			return Main.hardMode && NPC.downedGolemBoss && !NPC.AnyNPCs(NPCID.CultistBoss);
		}

		public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer) {
				// If the player using the item is the client
				// (explicitely excluded serverside here)
				SoundEngine.PlaySound(SoundID.Roar, player.position);

				int type = NPCID.CultistBoss;

				if (Main.netMode != NetmodeID.MultiplayerClient) {
					// If the player is not in multiplayer, spawn directly
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
				else {
					// If the player is in multiplayer, request a spawn
					// This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in this class above
					NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
				}
			}

			return true;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Ectoplasm, 10)
				.AddIngredient(ItemID.SpectreBar, 5)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}