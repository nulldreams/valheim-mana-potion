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
using ValheimManaPotion.Items;
using ValheimManaPotion.Builders;
using System.Linq;

namespace ValheimManaPotion
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    internal class ValheimManaPotion : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.ValheimManaPotion";
        public const string PluginName = "ValheimManaPotion";
        public const string PluginVersion = "0.0.1";

        public static ManualLogSource logger;
        public readonly Harmony harmony = new Harmony(PluginGUID);
        public static CustomLocalization Localization;

        public static float staminaRegenComplement = 0f;

        private void Awake()
        {
            logger = Logger;

            Localization = new CustomLocalization();
            LocalizationManager.Instance.AddLocalization(Localization);

            LocalizationBuilder.SetLocalizations(Localization, Potions.SmallStamina);
            LocalizationBuilder.SetLocalizations(Localization, Potions.SmallMana);
            LocalizationBuilder.SetLocalizations(Localization, Potions.MinorMana);
            LocalizationBuilder.SetLocalizations(Localization, Potions.MediumMana);
            LocalizationBuilder.SetLocalizations(Localization, Potions.GreaterMana);
            LocalizationBuilder.SetLocalizations(Localization, Potions.SuperMana);

            PrefabManager.OnVanillaPrefabsAvailable += CreateItem;

            harmony.PatchAll();
        }

        private void Update()
        {
            if (staminaRegenComplement > 0f)
            {
                var localPlayer = Player.m_localPlayer;
                var hasStaminaRegenEffect = localPlayer.GetSEMan().GetStatusEffects().Find(effect => effect.m_name.IndexOf("staminapotion") > -1);

                if (hasStaminaRegenEffect)
                {
                    localPlayer.AddStamina(staminaRegenComplement);
                }
            } else
            {
                staminaRegenComplement = 0f;
            }
        }

        private void CreateItem()
        {
            try
            {
                GenerateItem.GenerateManaPotions();
                GenerateItem.GenerateStaminaPotions();
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while adding cloned item: {ex.Message}");
            }
            finally
            {
                PrefabManager.OnVanillaPrefabsAvailable -= CreateItem;
            }
        }
    }
}

