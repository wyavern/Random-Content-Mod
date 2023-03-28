using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RandomContentModIII.Content.Rarities;

namespace RandomContentModIII.Content.Items.Other
{
	public class ModRarity2Item : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("GenericSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			// Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			Item.damage = 1;
			Item.DamageType = DamageClass.Melee;
			Item.crit = 100;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useTurn = true;
			Item.scale = 15;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 100000;
			Item.rare = ModContent.RarityType<ModRarity2>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
	}
}