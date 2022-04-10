using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;
using ValheimManaPotion.Items;

namespace ValheimManaPotion.Builders
{
    public static class RecipeBuilder
    {
        public static void GenerateRecipe(Potion potion, ItemDrop itemDrop, string recipeName)
        {
            if (potion.Type == PotionTypes.MANA)
            {
                switch (potion.Size)
                {
                    case PotionSize.SMALL:
                        SmallMana(itemDrop, recipeName);
                        break;
                    case PotionSize.MINOR:
                        MinorMana(itemDrop, recipeName);
                        break;
                    case PotionSize.MEDIUM:
                        MediumMana(itemDrop, recipeName);
                        break;
                    case PotionSize.GREATER:
                        GreaterMana(itemDrop, recipeName);
                        break;
                    case PotionSize.SUPER:
                        SuperMana(itemDrop, recipeName);
                        break;
                }
            } else if (potion.Type == PotionTypes.STAMINA)
            {
                MinorStamina(itemDrop, recipeName);
            }
        }

        private static void MinorStamina(ItemDrop itemDrop, string recipeName)
        {
            Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.m_item = itemDrop;
            recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_cauldron");
            recipe.m_resources = new[]
            {
                    new Piece.Requirement
                    {
                        m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("MushroomYellow"),
                        m_amount = 5
                    }
            };

            var customRecipe = new CustomRecipe(recipe, fixReference: false, fixRequirementReferences: false);
            ItemManager.Instance.AddRecipe(customRecipe);
        }

        private static void MinorMana(ItemDrop itemDrop, string recipeName)
        {
            Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.m_item = itemDrop;
            recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_cauldron");
            recipe.m_resources = new[]
            {
                    new Piece.Requirement
                    {
                        m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Blueberries"),
                        m_amount = 5
                    }
            };

            var customRecipe = new CustomRecipe(recipe, fixReference: false, fixRequirementReferences: false);
            ItemManager.Instance.AddRecipe(customRecipe);
        }

        private static void SmallMana(ItemDrop itemDrop, string recipeName)
        {
            Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.m_item = itemDrop;
            recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_cauldron");
            recipe.m_resources = new[]
            {
                    new Piece.Requirement
                    {
                        m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Blueberries"),
                        m_amount = 8
                    }
            };

            var customRecipe = new CustomRecipe(recipe, fixReference: false, fixRequirementReferences: false);
            ItemManager.Instance.AddRecipe(customRecipe);
        }

        private static void MediumMana(ItemDrop itemDrop, string recipeName)
        {
            Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.m_item = itemDrop;
            recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_cauldron");
            recipe.m_resources = new[]
            {
                    new Piece.Requirement
                    {
                        m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Blueberries"),
                        m_amount = 10
                    }
            };

            var customRecipe = new CustomRecipe(recipe, fixReference: false, fixRequirementReferences: false);
            ItemManager.Instance.AddRecipe(customRecipe);
        }

        private static void GreaterMana(ItemDrop itemDrop, string recipeName)
        {
            Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.m_item = itemDrop;
            recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_cauldron");
            recipe.m_resources = new[]
            {
                    new Piece.Requirement
                    {
                        m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Blueberries"),
                        m_amount = 15
                    },
                    new Piece.Requirement
                    {
                        m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("GreydwarfEye"),
                        m_amount = 5
                    }
            };

            var customRecipe = new CustomRecipe(recipe, fixReference: false, fixRequirementReferences: false);
            ItemManager.Instance.AddRecipe(customRecipe);
        }

        private static void SuperMana(ItemDrop itemDrop, string recipeName)
        {
            Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.m_item = itemDrop;
            recipe.m_craftingStation = PrefabManager.Cache.GetPrefab<CraftingStation>("piece_cauldron");
            recipe.m_resources = new[]
            {
                    new Piece.Requirement
                    {
                        m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("Blueberries"),
                        m_amount = 15
                    },
                    new Piece.Requirement
                    {
                        m_resItem = PrefabManager.Cache.GetPrefab<ItemDrop>("GreydwarfEye"),
                        m_amount = 10
                    }
            };

            var customRecipe = new CustomRecipe(recipe, fixReference: false, fixRequirementReferences: false);
            ItemManager.Instance.AddRecipe(customRecipe);
        }
    }
}
