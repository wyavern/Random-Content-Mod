using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RandomContentModIII.Content.Projectiles;

namespace RandomContentModIII.Content.Items.Weapons
{
	public class ElementalAgony : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Agony");
			Tooltip.SetDefault("wyavern's favourite calamity mod weapon, which he wanted to bring into his mod."
			+ "\nShoots a colorless elemental beam which does high amounts of damage."
			+ "\nThe sprite is Calamity Mod's Elemental Excalibur"
			+ "\nIt should only be used for testing.");
		}
		public override void SetDefaults()
		{
			Item.damage = 950000;
			Item.DamageType = DamageClass.Melee;
			Item.crit = 60;
			Item.width = 112;
			Item.height = 112;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useTurn = true;
			Item.scale = 1;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = int.MaxValue;
			Item.rare = 12;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<ElementalAgonyBeam>(); 
			Item.shootSpeed = 20f;
		}
	}
}