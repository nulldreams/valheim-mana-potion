using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ValheimManaPotion.Items
{
    public abstract class ManaPotion
    {
        private string name;
        private string nameId;
        private string descriptionId;
        private float manaRecovery;
        private Sprite icon;
        private string recipeName;

        public string RecipeName { get => recipeName; set => recipeName = value; }
        public string Name { get => name; set => name = value; }
        public string NameId { get => nameId; set => nameId = value; }
        public string DescriptionId { get => descriptionId; set => descriptionId = value; }
        public float ManaRecovery { get => manaRecovery; set => manaRecovery = value; }

        public void Init(string name, float manaRecovery)
        {
            this.Name = name;
            this.ManaRecovery = manaRecovery * (-1);

            this.recipeName = $"Recipe_{Utils.RemoveSpaces(name)}";
            this.NameId = GenerateItemId(Utils.RemoveSpacesToLower(name));
            this.DescriptionId = GenerateItemDescId(Utils.RemoveSpacesToLower(name));
            this.icon = AssetUtils.LoadSpriteFromFile($"ValheimManaPotion/Assets/{Utils.RemoveSpaces(name)}.png");
        }

        public void GenerateItem()
        {
            CreateRecipe(CreateItem(CloneItem()));
        }

        private CustomItem CloneItem()
        {
            CustomItem customItem = new CustomItem(Utils.RemoveSpaces(this.Name), "MeadPoisonResist");
            ItemManager.Instance.AddItem(customItem);

            return customItem;
        }

        private ItemDrop CreateItem(CustomItem customItem)
        {
            var itemDrop = customItem.ItemDrop;
            itemDrop.m_itemData.m_shared.m_name = this.NameId;
            itemDrop.m_itemData.m_shared.m_description = this.DescriptionId;
            itemDrop.m_itemData.m_shared.m_foodStamina = this.ManaRecovery;

            itemDrop.m_itemData.m_shared.m_consumeStatusEffect = CreateStatusEffect();

            Sprite[] listSprite = { this.icon };
            itemDrop.m_itemData.m_shared.m_icons = listSprite;

            return itemDrop;
        }

        public abstract void CreateRecipe(ItemDrop itemDrop);

        private StatusEffect CreateStatusEffect()
        {
            var effect = ScriptableObject.CreateInstance<StatusEffect>();

            effect.name = $"{Utils.RemoveSpaces(Name)}Effect";
            effect.m_name = "manapotion_effectname";
            effect.m_ttl = 1f;

            effect.m_icon = this.icon;

            effect.m_startMessageType = MessageHud.MessageType.Center;
            effect.m_startMessage = "manapotion_effectstart";

            effect.m_stopMessageType = MessageHud.MessageType.Center;
            effect.m_stopMessage = "manapotion_effectstop";

            var manaEffect = new CustomStatusEffect(effect, fixReference: false);

            ItemManager.Instance.AddStatusEffect(manaEffect);

            return manaEffect.StatusEffect;
        }

        private string GenerateItemId(string itemName)
        {
            return $"$item_{itemName}";
        }
        private string GenerateItemDescId(string itemName)
        {
            return $"$item_{itemName}_desc";
        }
    }
}
