using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    private Item _currentItem;
    public Image customCursor;

    public Slot[] craftingSlots;

    public List<Item> itemList;
    public string[] recipes;
    public Item[] recipeResults;
    public Slot resultSlot;
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
                    if (dist<shortestDistance)
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

        string currentRecipeString = "";
        foreach (Item item in itemList)//check itemlist for currentRecipeString
        {
            if (item!=null)
            {
                currentRecipeString += item.itemName;
            }else
            {
                currentRecipeString += "null";
            }
        }
        for (int i=0; i<recipes.Length;i++)//check recipe list for a match with currentRecipeString
        {
            if (recipes[i]==currentRecipeString)
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
        if (_currentItem ==null)
        {
            _currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = _currentItem.GetComponent<Image>().sprite;
        }
    }
}
