using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DarkShadowHunter
{
    public class CraftingManager : MonoBehaviour
    {
        private Item _currentItem;
        public Image customCursor;

        public Slot[] craftingSlots;

        public List<Item> itemList;
        public InventoryDataContainer SO_Data;
        public string[] recipes;
        public Item[] recipeResults;
        public Slot resultSlot;
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

            for (int i =0;i< currentRecipeString.Length;i++)//empty the array
            {
                currentRecipeString[i] = "";
            }
            for(int i = 0; i < itemList.Count; i++)//check itemlist for currentRecipeString
            {
                 currentRecipeString[i] = itemList[i].itemName;
            }
            for (int i = 0; i < recipes.Length; i++)//check recipe list for a match with currentRecipeString
            {
                Debug.LogError(currentRecipeString.ToString());
                if (recipes[i] == currentRecipeString.ToString())
                {
                    resultSlot.gameObject.SetActive(true);
                    resultSlot.GetComponent<Image>().sprite = recipeResults[i].GetComponent<Image>().sprite;
                    resultSlot.item = recipeResults[i];
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
            int materialNeededCouter = 0;
            if (resultSlot.item!=null)
            {
                for(int i = 0; i < currentRecipeString.Length; i++)
                {
                    if (currentRecipeString[i]!= "")
                    {
                        materialNeededCouter++;
                        if (SO_Data.inventoryData[i].inventoryItemCounter>=1) {
                            materialNeededCouter--;
                        }
                    }

                }
            }
            if (materialNeededCouter == 0)
            {
                for (int i = 0; i < currentRecipeString.Length; i++)
                {
                    if (currentRecipeString[i] != "")
                    {
                        SO_Data.inventoryData[i].inventoryItemCounter--;//use material in SO database
                    }
                }
                //do something to add things in inventory

            }
            
        }
    }
}
