/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using  RandomContentModIII.Content.Items.Other;

namespace RandomContentModIII.Common.GlobalNPCs
{
	public class ModGlobalNPC : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.Spazmatism)
			{
				if (Main.rand.Next(2) == 0) //item rarity
				{
					if (npc.type(>)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (ModContent.ItemType<MechUpgradeKit>())// If using a modded item, mod.ItemType("mod item id")>);
					}
					//npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MechUpgradeKit>()));
				}
			}
		}
	}
}*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using  RandomContentModIII.Content.Items.Other;

namespace RandomContentModIII.Common.GlobalNPCs
{
	public class ModGlobalNPC : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) 
		{
			if (npc.type == NPCID.Spazmatism) 
			{
				LeadingConditionRule leadingConditionRule = new LeadingConditionRule(new Conditions.MissingTwin());
				leadingConditionRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<MechUpgradeKit>(), 4));
				npcLoot.Add(leadingConditionRule);
				//npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MechUpgradeKit>(), 4));
			}

			/*if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
			{
				LeadingConditionRule leadingConditionRule = new LeadingConditionRule(new Conditions.MissingTwin());
				leadingConditionRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<MechUpgradeKit>(), 4));
				//leadingConditionRule.OnSuccess(//Additional rules as new lines);
				npcLoot.Add(leadingConditionRule);
			}*/

			if (npc.type == NPCID.QueenSlimeBoss) 
			{
				LeadingConditionRule leadingConditionRule = new LeadingConditionRule(new Conditions.BeatAnyMechBoss());
				leadingConditionRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<PlasmaNucleus>(), 400));
				npcLoot.Add(leadingConditionRule);
				//npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MechUpgradeKit>(), 4));
			}
		}
	}
}