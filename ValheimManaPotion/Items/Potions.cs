namespace ValheimManaPotion.Items
{
    public static class Potions
    {
        private static readonly string ManaPotionDescription = "A drink created by ancient wizards. Restores magical powers upon ingesting it.";
        private static readonly string StaminaPotionDescription = "A drink created from the cursed mushrooms of the Black Forest dungeons.";

        public static Potion SmallMana = new Potion(PotionTypes.MANA, PotionSize.SMALL, "Small Mana Potion", ManaPotionDescription);
        public static Potion MinorMana = new Potion(PotionTypes.MANA, PotionSize.MINOR, "Minor Mana Potion", ManaPotionDescription);
        public static Potion MediumMana = new Potion(PotionTypes.MANA, PotionSize.MEDIUM, "Medium Mana Potion", ManaPotionDescription);
        public static Potion GreaterMana = new Potion(PotionTypes.MANA, PotionSize.GREATER, "Greater Mana Potion", ManaPotionDescription);
        public static Potion SuperMana = new Potion(PotionTypes.MANA, PotionSize.SUPER, "Super Mana Potion", ManaPotionDescription);

        public static Potion SmallStamina = new Potion(PotionTypes.STAMINA, PotionSize.SMALL, "Small Stamina Potion", StaminaPotionDescription);
    }
}
