using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestAntiDamage
{
    public class CrestAntiDamageConfiguration : IRocketPluginConfiguration
    {
        public HashSet<ushort> WhitelistedDestroy;
        public void LoadDefaults()
        {
            WhitelistedDestroy = new HashSet<ushort>{ 369, 328 };
        }
    }
}
