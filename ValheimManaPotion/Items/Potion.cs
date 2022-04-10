using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimManaPotion.Items
{
    public enum PotionTypes
    {
        MANA,
        HEALTH,
        STAMINA,
    }

    public enum PotionSize
    {
        MINOR = 10,
        SMALL = 20,
        MEDIUM = 35,
        GREATER = 50,
        SUPER = 100
    }

    public class Potion
    {
        private PotionTypes type;
        private PotionSize size;

        private string name;
        private string description;
        private float restoreAmount;

        public Potion(PotionTypes type, PotionSize size, string name, string description)
        {
            this.Size = size;
            this.type = type;
            this.Name = name;
            this.Description = description;

            if (type == PotionTypes.MANA)
            {
                this.RestoreAmount = (float)size * (-1);
            }

            if (type == PotionTypes.STAMINA)
            {
                this.RestoreAmount = 5f;
            }
        }

        public PotionTypes Type { get => type; set => type = value; }
        public PotionSize Size { get => size; set => size = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public float RestoreAmount { get => restoreAmount; set => restoreAmount = value; }
    }
}
