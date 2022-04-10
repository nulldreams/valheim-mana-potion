using System;
using HarmonyLib;
using System.Linq;
using skyheim;

namespace ValheimManaPotion.Patches
{
    [HarmonyPatch(typeof(Player), "ConsumeItem")]
    public static class PlayerConsumeItem
    {
        [HarmonyPrefix]
        private static void Postfix(ref Inventory inventory, ref ItemDrop.ItemData item)
        {
            if (item.m_shared.m_name.IndexOf("manapotion") > -1)
            {
                var skyheimItem = new SkyheimItemData();
                skyheimItem.ManaUsed = item.m_shared.m_aiAttackInterval;
                SkyheimMana.Instance.ConsumeMana(skyheimItem);
            }

            if (item.m_shared.m_name.IndexOf("staminapotion") > -1)
            {
                ValheimManaPotion.staminaRegenComplement = item.m_shared.m_aiAttackInterval;
            }
        }
    }
}
