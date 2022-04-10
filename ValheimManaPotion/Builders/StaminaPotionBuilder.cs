using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ValheimManaPotion.Items;

namespace ValheimManaPotion.Builders
{
    class StaminaPotionBuilder
    {
        private string name;
        private string description;
        private Sprite icon;
        private Potion potion;

        private string recipeName;
        private string nameId;
        private string descriptionId;

        public StaminaPotionBuilder(Potion potion)
        {
            this.name = potion.Name;
            this.description = potion.Description;
            this.potion = potion;

            this.recipeName = $"Recipe_{Utils.RemoveSpaces(name)}";
            this.nameId = Utils.GenerateItemId(Utils.RemoveSpacesToLower(name));
            this.descriptionId = Utils.GenerateItemDescId(Utils.RemoveSpacesToLower(name));
            this.icon = AssetUtils.LoadSpriteFromFile($"ValheimManaPotion/Assets/{Utils.RemoveSpaces(name)}.png");
        }

        public void GenerateItem()
        {
            var clonedItem = this.CloneItem();
            var createdItem = this.CreateItem(clonedItem);
            RecipeBuilder.GenerateRecipe(this.potion, createdItem, this.recipeName);
        }

        private CustomItem CloneItem()
        {
            CustomItem customItem = new CustomItem(Utils.RemoveSpaces(this.name), "MeadStaminaMinor");
            ItemManager.Instance.AddItem(customItem);

            return customItem;
        }

        private ItemDrop CreateItem(CustomItem customItem)
        {
            var itemDrop = customItem.ItemDrop;
            itemDrop.m_itemData.m_shared.m_name = this.nameId;
            itemDrop.m_itemData.m_shared.m_description = this.descriptionId;
            itemDrop.m_itemData.m_shared.m_aiAttackInterval = this.potion.RestoreAmount;

            itemDrop.m_itemData.m_shared.m_consumeStatusEffect = CreateStatusEffect();

            Sprite[] listSprite = { this.icon };
            itemDrop.m_itemData.m_shared.m_icons = listSprite;

            return itemDrop;
        }

        private StatusEffect CreateStatusEffect()
        {
            var effect = ScriptableObject.CreateInstance<StatusEffect>();

            effect.name = $"{Utils.RemoveSpaces(this.name)}Effect";
            effect.m_name = $"${Utils.RemoveSpacesToLower(this.name)}_effectname";
            effect.m_ttl = 20f;

            effect.m_icon = AssetUtils.LoadSpriteFromFile($"ValheimManaPotion/Assets/StaminaRegen.png");

            effect.m_startMessageType = MessageHud.MessageType.Center;
            effect.m_startMessage = $"{Utils.RemoveSpacesToLower(this.name)}_effectstart";

            effect.m_stopMessageType = MessageHud.MessageType.Center;
            effect.m_stopMessage = $"{Utils.RemoveSpacesToLower(this.name)}_effectstop";

            var manaEffect = new CustomStatusEffect(effect, fixReference: false);

            ItemManager.Instance.AddStatusEffect(manaEffect);

            return manaEffect.StatusEffect;
        }
    }
}
