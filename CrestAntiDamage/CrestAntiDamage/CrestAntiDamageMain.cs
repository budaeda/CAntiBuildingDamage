using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace CrestAntiDamage
{
    public class CrestAntiDamageMain : RocketPlugin<CrestAntiDamageConfiguration>
    {
        public static CrestAntiDamageMain Instance { get; private set; }
        public DamageRequested DRS { get; private set; }

        protected override void Load()
        {
            Instance = this;

            DRS = new DamageRequested();
            Logger.Log($"{Assembly.GetName().Name} Version {Assembly.GetName().Version} Has Loaded");
        }

        protected override void Unload()
        {
            DRS.Destroy();
            Logger.Log($"{Assembly.GetName().Name} Version {Assembly.GetName().Version} Has Unloaded");
        }
    }
}
