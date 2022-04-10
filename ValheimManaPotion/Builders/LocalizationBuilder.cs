using Jotunn.Entities;
using System;
using System.Collections.Generic;
using ValheimManaPotion.Items;

namespace ValheimManaPotion.Builders
{
    public static class LocalizationBuilder
    {
        public static void SetLocalizations(CustomLocalization localization, Potion potion)
        {
            var nameId = Utils.GenerateItemId(Utils.RemoveSpacesToLower(potion.Name));
            var descriptionId = Utils.GenerateItemDescId(Utils.RemoveSpacesToLower(potion.Name));

            var eng = new Dictionary<string, string>
            {
                {Utils.RemoveDollarSign(nameId), potion.Name},
                {Utils.RemoveDollarSign(descriptionId), potion.Description},
            };

            if (potion.Type == PotionTypes.MANA)
            {
                eng.Add($"{Utils.RemoveSpacesToLower(potion.Name)}_effectname", $"Restore {potion.RestoreAmount} MP");
                eng.Add($"{Utils.RemoveSpacesToLower(potion.Name)}_effectstart", "Hmm glub glub");
                eng.Add($"{Utils.RemoveSpacesToLower(potion.Name)}_effectstop", "Delicious...");
            }

            if (potion.Type == PotionTypes.STAMINA)
            {
                eng.Add($"{Utils.RemoveSpacesToLower(potion.Name)}_effectname", $"Increase stamina regen in {potion.RestoreAmount} per sec.");
                eng.Add($"{Utils.RemoveSpacesToLower(potion.Name)}_effectstart", "Hmm glub glub");
                eng.Add($"{Utils.RemoveSpacesToLower(potion.Name)}_effectstop", "Delicious...");
            }

            localization.AddTranslation("English", eng);
        }
    }
}
