using System;
using HarmonyLib;
using System.Linq;
using skyheim;

namespace ValheimManaPotion.Patches
{
    [HarmonyPatch(typeof(Player), "EatFood")]
    public static class PlayerConsumeItem
    {
        [HarmonyPrefix]
        private static void Postfix(ref ItemDrop.ItemData item)
        {
            ValheimManaPotion.logger.LogInfo("================ ITEM LOG ================");
            if (item.m_shared.m_name.IndexOf("potion") > -1)
            {
                var teste = new SkyheimItemData();
                teste.ManaUsed = item.m_shared.m_foodStamina;
                SkyheimMana.Instance.ConsumeMana(teste);
            }
            ValheimManaPotion.logger.LogInfo("================ ITEM LOG ================");
        }
    }
}
