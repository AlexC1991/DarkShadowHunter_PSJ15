using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DarkShadowHunter.PotionCraftingDataBase;

namespace DarkShadowHunter
{
    public class CraftingManager : MonoBehaviour
    {
        [Header("UI hook up")]
        private Item _currentItem;
        public Image customCursor;

        public Slot[] craftingSlots;
        public Slot resultSlot;
        public List<Item> itemList;
        [Header("Databases")]
        [SerializeField] private InventoryDataContainer _IDC;
        [SerializeField] private InventoryManager _inventoryManager;
        [SerializeField] private PotionCraftingDataBase _potionCraftingData;

        [Header("Parameter for crafting potion")]
        [SerializeField] private float craftCapacity = 30f;
        
        public string[] currentRecipeString = new string[4];

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (_currentItem != null)
                {
                    customCursor.gameObject.SetActive(false);
                    Slot nearestSlot = null;
                    float shortestDistance = float.MaxValue;
                    foreach (Slot slot in craftingSlots)
                    {
                        float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);
                        if (dist < shortestDistance)
                        {
                            shortestDistance = dist;
                            nearestSlot = slot;
                        }
                    }
                    nearestSlot.gameObject.SetActive(true);
                    nearestSlot.GetComponent<Image>().sprite = _currentItem.GetComponent<Image>().sprite;
                    nearestSlot.item = _currentItem;
                    itemList[nearestSlot.index] = _currentItem;

                    _currentItem = null;

                    CheckforCreatedRecipes();
                }
            }
        }

        void CheckforCreatedRecipes()
        {
            resultSlot.gameObject.SetActive(false);
            resultSlot.item = null;
            string tempRecipe = "";
            
            //var recipes = Enum.GetValues(typeof(PotionCraftingDataBase.PotionIngredients));
            for (int i =0;i< currentRecipeString.Length;i++)//empty the array
            {
                currentRecipeString[i] = "";
            }
            for(int i = 0; i < itemList.Count; i++)//check itemlist for currentRecipeString
            {
                if (itemList[i]!=null)
                {
                    currentRecipeString[i] = itemList[i].itemName;
                    tempRecipe += currentRecipeString[i];
                }
            }
            Debug.Log("temprecipe is "+tempRecipe);
            Debug.Log("_potionCraftingData is " + _potionCraftingData.potionsToCraft[0].potionIngredients.ToString());
            for (int i=0;i< _potionCraftingData.potionsToCraft.Length;i++)
            {
                if (_potionCraftingData.potionsToCraft[i].potionIngredients.ToString() == tempRecipe)
                {
                    resultSlot.gameObject.SetActive(true);
                    resultSlot.item = new Item();
                    resultSlot.item.itemName = _potionCraftingData.potionsToCraft[i].nameOfPotion;
                    resultSlot.GetComponent<Image>().sprite = _potionCraftingData.potionsToCraft[i].potionIcon;
                }
            }
        }
        public void OnClickSlot(Slot slot)
        {
            //delete clicked slot item and check for recipe
            slot.item = null;
            itemList[slot.index] = null;
            slot.gameObject.SetActive(false);
            CheckforCreatedRecipes();
        }
        public void OnMouseDownItem(Item item)
        {
            //drag material
            if (_currentItem == null)
            {
                _currentItem = item;
                customCursor.gameObject.SetActive(true);
                customCursor.sprite = _currentItem.GetComponent<Image>().sprite;
            }
        }
        public void OnCraftButtonDown()
        {
            if (resultSlot.item != null)
            {
                for (int i = 0; i < currentRecipeString.Length; i++)
                {
                    if (currentRecipeString[i] != "")
                    {
                        if (_IDC.inventoryData[i].inventoryItemCounter < 1)//if not enough material, return and do nothing
                        {
                            return;//do nothing
                        }
                    }

                }
            }
            else
            {
                for (int i = 0; i < currentRecipeString.Length; i++)
                {
                    if (currentRecipeString[i] != "")
                    {
                        for (int j = 0; j < _IDC.inventoryData.Length; j++)
                        {
                            if (currentRecipeString[i] == _IDC.inventoryData[j].inventoryItemName)
                            {
                                if (_IDC.inventoryData[j].inventoryItemCounter>0)
                                {
                                    _IDC.inventoryData[j].inventoryItemCounter--;//use material in SO database
                                    _inventoryManager.AddItemToInventory(_IDC.inventoryData[j].inventoryItemName, _IDC.inventoryData[j].inventoryItemCounter, _IDC.inventoryData[j].inventoryItemSprite);//just update not add
                                }
                                else
                                {
                                    return;
                                }
                                
                            }
                        }
                    }
                }
                for (int i = 0; i < _potionCraftingData.potionsToCraft.Length; i++)
                {
                    if (resultSlot.item.itemName == _potionCraftingData.potionsToCraft[i].nameOfPotion)
                    {
                        _potionCraftingData.potionsToCraft[i].potionCapacity += craftCapacity;//add potion to database
                        //add potion to inventory
                    }
                }
            }
                     
        }
    }
}
