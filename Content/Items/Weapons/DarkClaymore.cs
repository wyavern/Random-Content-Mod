using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class DarkClaymore : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Claymore");
			Tooltip.SetDefault("The ultimate reward");
		}
		public override void SetDefaults()
		{
			Item.damage = 1000;
			Item.DamageType = DamageClass.Melee;
			Item.crit = 50;
			Item.width = 160;
			Item.height = 160;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useTurn = true;
			Item.scale = 1;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 9999999;
			Item.rare = 12;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
	}
}