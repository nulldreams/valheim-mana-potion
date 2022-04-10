using System.Collections.Generic;
using ValheimManaPotion.Builders;

namespace ValheimManaPotion.Items
{
    public static class GenerateItem
    {
        public static void GenerateManaPotions()
        {
            ManaPotionBuilder[] potions = { 
                new ManaPotionBuilder(Potions.MinorMana),
                new ManaPotionBuilder(Potions.SmallMana),
                new ManaPotionBuilder(Potions.MediumMana),
                new ManaPotionBuilder(Potions.GreaterMana),
                new ManaPotionBuilder(Potions.SuperMana)
            };

            var potionList = new List<ManaPotionBuilder>(potions);

            foreach (var potion in potionList)
            {
                potion.GenerateItem();
            }
        }

        public static void GenerateStaminaPotions()
        {
            StaminaPotionBuilder[] potions = {
                new StaminaPotionBuilder(Potions.SmallStamina),
            };

            var potionList = new List<StaminaPotionBuilder>(potions);

            foreach (var potion in potionList)
            {
                potion.GenerateItem();
            }
        }
    }
}
