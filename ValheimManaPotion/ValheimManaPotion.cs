// ValheimManaPotion
// a Valheim mod skeleton using Jötunn
// 
// File:    ValheimManaPotion.cs
// Project: ValheimManaPotion

using BepInEx;
using BepInEx.Logging;
using Jotunn.Entities;
using Jotunn.Managers;
using HarmonyLib;
using System;
using UnityEngine;
using skyheim;

namespace ValheimManaPotion
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class ValheimManaPotion : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.ValheimManaPotion";
        public const string PluginName = "ValheimManaPotion";
        public const string PluginVersion = "0.0.1";
        public static ManualLogSource logger;
        public readonly Harmony harmony = new Harmony(PluginGUID);
            public static bool regenMana = false;

        private void Awake()
        {
            logger = Logger;
            PrefabManager.OnVanillaPrefabsAvailable += CreateItem;

            harmony.PatchAll();
        }

        private void CreateItem()
        {
            try
            {
                CustomItem customItem = new CustomItem("ManaPotion", "MeadPoisonResist");
                ItemManager.Instance.AddItem(customItem);

                var itemDrop = customItem.ItemDrop;
                itemDrop.m_itemData.m_shared.m_name = "$item_manapotion";
                itemDrop.m_itemData.m_shared.m_description = "$item_manapotion_desc";
                itemDrop.m_itemData.m_shared.m_foodStamina = -50;

                Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
                recipe.name = "Recipe_ManaPotion";
                recipe.m_item = itemDrop;
                recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_cauldron");
                recipe.m_resources = new[]
                {
                    new Piece.Requirement
                    {
                        m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Blueberries"),
                        m_amount = 15
                    }
                };

                var customRecipe = new CustomRecipe(recipe, fixReference: false, fixRequirementReferences: false);
                ItemManager.Instance.AddRecipe(customRecipe);
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while adding cloned item: {ex.Message}");
            }
            finally
            {
                // You want that to run only once, Jotunn has the item cached for the game session
                PrefabManager.OnVanillaPrefabsAvailable -= CreateItem;
            }
        }
    }
}

