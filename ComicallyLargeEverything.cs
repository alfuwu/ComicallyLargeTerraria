using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace ComicallyLargeEverything
{
    public class ComicallyLargeEverything : Mod
    {
        // nothing to put here
    }
    
    public class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool Enabled = true;

        [Header("Modifiers")]

        [DefaultValue(1f)]
        [Range(0f, 100f)]
        [ReloadRequired]
        public float RollChance = 1;

        [DefaultValue(1f)]
        [Range(1f, 10f)]
        [ReloadRequired]
        public float Size = 1;

        [DefaultValue(1)]
        [Range(0.1f, 10f)]
        [ReloadRequired]
        public float UseTime = 1;

        [DefaultValue(1f)]
        [Range(0.1f, 10f)]
        [ReloadRequired]
        public float Knockback = 1;

        [DefaultValue(1f)]
        [Range(0.1f, 10f)]
        [ReloadRequired]
        public float Value = 1;
    }

    public class ComicallyLarge : ModPrefix
    {
        public override PrefixCategory Category => PrefixCategory.AnyWeapon; // sadly accessories cant be made big (easily) :c

        public override float RollChance(Item item)
        {
            return ModContent.GetInstance<Config>().RollChance;
        }

        public override bool CanRoll(Item item)
        {
            return ModContent.GetInstance<Config>().Enabled && item.useStyle != ItemUseStyleID.Thrust; // no short swords (doesn't work)
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            useTimeMult *= (float) ((2 * ModContent.GetInstance<Config>().UseTime) * ModContent.GetInstance<Config>().Size);
            knockbackMult *= (float) (2 * ModContent.GetInstance<Config>().Size * ModContent.GetInstance<Config>().Knockback);
            scaleMult *= (float) (10 * ModContent.GetInstance<Config>().Size);
            damageMult *= (float) (2 * ModContent.GetInstance<Config>().Size);
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= (float) (1.25 * ModContent.GetInstance<Config>().Value);
        }
    }
}