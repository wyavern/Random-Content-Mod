using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RandomContentModIII.Content.Items.Consumables;

namespace RandomContentModIII.Content.Items.Consumables
{
	// This is the Item used to summon a boss, in this case the vanilla Plantera boss.
	public class GolemSpawnerInfinite : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Power Cell");
			Tooltip.SetDefault("Not consumable"
			+ "\nSummons Golem"
			+ "\nReally? You're this lazy to move a lihzahrd altar?"
			+ "\nOh well, I get it."
			+ "\nDoes not need a lihzahrd altar to summon Golem."
			+ "\nCan't be used before plantera has been defeated.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
			ItemID.Sets.SortingPriorityBossSpawns[Type] = 12; // This helps sort inventory know that this is a boss summoning Item.

			// This is set to true for all NPCs that can be summoned via an Item (calling NPC.SpawnOnPlayer). If this is for a modded boss,
			// write this in the bosses file instead
			NPCID.Sets.MPAllowedEnemies[NPCID.Golem] = false;
		}

		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 12;
			Item.maxStack = 1;
			Item.value = 100;
			Item.rare = ItemRarityID.Lime;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = false;
		}

		public override bool CanUseItem(Player player) {
			// If you decide to use the below UseItem code, you have to include !NPC.AnyNPCs(id), as this is also the check the server does when receiving MessageID.SpawnBoss
			return Main.hardMode && NPC.downedPlantBoss && !NPC.AnyNPCs(NPCID.Golem);
		}

		public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer) {
				// If the player using the item is the client
				// (explicitely excluded serverside here)
				SoundEngine.PlaySound(SoundID.Roar, player.position);

				int type = NPCID.Golem;

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

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<GolemSpawner>(20)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}