using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CrestAntiDamage
{
    public class DamageRequested
    {
        public DamageRequested()
        {
            BarricadeManager.onDamageBarricadeRequested += Event_onDamageBarricadeRequested;
            StructureManager.onDamageStructureRequested += Event_OnDamageStructureRequested;
        }

        CrestAntiDamageConfiguration Config = CrestAntiDamageMain.Instance.Configuration.Instance;
        private void Event_onDamageBarricadeRequested(CSteamID instigatorSteamID, Transform barricadeTransform, ref ushort pendingTotalDamage, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            BarricadeDrop barricadeDrop = BarricadeManager.FindBarricadeByRootTransform(barricadeTransform);
            if (barricadeDrop.asset.type == EItemType.FARM || Config.WhitelistedDestroy.Contains(barricadeDrop.asset.id))
            {
                shouldAllow = true;
                return;
            }
            shouldAllow = false;
        }

        private void Event_OnDamageStructureRequested(CSteamID instigatorSteamID, Transform structureTransform, ref ushort pendingTotalDamage, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            StructureDrop structureDrop = StructureManager.FindStructureByRootTransform(structureTransform);
            if (Config.WhitelistedDestroy.Contains(structureDrop.asset.id))
            {
                shouldAllow = true;
                return;
            }
            shouldAllow = false;
        }

        public void Destroy()
        {
            BarricadeManager.onDamageBarricadeRequested -= Event_onDamageBarricadeRequested;
            StructureManager.onDamageStructureRequested -= Event_OnDamageStructureRequested;
        }
    }
}
