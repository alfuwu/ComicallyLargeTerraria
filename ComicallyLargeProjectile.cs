using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace ComicallyLargeEverything {
    public class ComicallyLargeProjectile : GlobalProjectile {
        //public override bool InstancePerEntity => true;
        //public Item sourceItem;

        public override void OnSpawn(Projectile projectile, IEntitySource source) {
            if (source is EntitySource_ItemUse itemSource) {
                if (itemSource.Item.prefix == ModContent.PrefixType<ComicallyLarge>()) {
                    projectile.scale *= 10 * ModContent.GetInstance<Config>().Size;
                    if (projectile.aiStyle == ProjAIStyleID.Spear || projectile.aiStyle == ProjAIStyleID.ShortSword) // these items need to get a velocity buff, otherwise they're too slow
                        projectile.velocity *= 4.5f * ModContent.GetInstance<Config>().Size / ModContent.GetInstance<Config>().UseTime;
                }
            }
        }
    }
}
