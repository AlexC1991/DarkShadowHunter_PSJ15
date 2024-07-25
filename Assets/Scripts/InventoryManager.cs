using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DarkShadowHunter
{
    public class InventoryManager : MonoBehaviour
    {
        [Header("Inventory Screen")] [SerializeField]
        private GameObject inventoryScreen;

        [Header("Slots Of The Inventory")] [SerializeField]
        private GameObject[] inventorySlots;

        [Header("Inventory Item Image Slot Control")] [SerializeField]
        private Image[] inventoryItemImageSlot;

        [Header(("Inventory Item Name Text Control"))] [SerializeField]
        private TextMeshProUGUI[] inventoryItemNameText;

        [Header("Inventory Item Counter Text Control")] [SerializeField]
        private TextMeshProUGUI[] inventoryCounterText;

        private int _allInventoryItemCounter;
        private int _buttonToOpenCounter = 0;

        struct CurrentInventoryData
        {
            public string inventoryItemName;
            public int inventoryItemCounter;
            public Sprite inventoryItemIcon;
            public GameObject inventoryItemSlotGameObject;
        }

        [SerializeField] List<CurrentInventoryData> currentInventoryData = new List<CurrentInventoryData>(8);

        private void Awake()
        {
            currentInventoryData.Clear();
            for (int i = 0; i < currentInventoryData.Count; i++)
            {
                int displayCounter = i;
                Debug.Log(displayCounter);
            }

            _allInventoryItemCounter = 0;
            _buttonToOpenCounter = 0;

            for (int i = 0; i < inventorySlots.Length; i++)
            {
                CurrentInventoryData inventoryData = new CurrentInventoryData
                {
                    inventoryItemSlotGameObject = inventorySlots[i],
                };
                currentInventoryData.Add(inventoryData);

                inventorySlots[i].GetComponent<CanvasGroup>().alpha = 0;
            }

            for (int i = 0; i < currentInventoryData.Count; i++)
            {
                Debug.Log("Inventory Slots Added " + " " + inventorySlots[i]);
            }

            foreach (var t in inventoryCounterText)
            {
                t.text = "0";
            }

            foreach (var t in inventoryItemNameText)
            {
                t.text = "";
            }

            inventoryScreen.GetComponent<CanvasGroup>().alpha = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _buttonToOpenCounter++;

                if (_buttonToOpenCounter % 2 == 0)
                {
                    StartCoroutine(CloseInventory());
                }
                else
                {
                    StartCoroutine(OpenTheInventory());
                }

                if (_buttonToOpenCounter > 1)
                {
                    _buttonToOpenCounter = 0;
                }
            }
        }

        private IEnumerator OpenTheInventory()
        {
            inventoryScreen.GetComponent<CanvasGroup>().alpha = 1;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(ManagingInventory());
        }

        private IEnumerator CloseInventory()
        {
            inventoryScreen.GetComponent<CanvasGroup>().alpha = 0;
            yield return new WaitForSeconds(0.1f);
        }

        public void AddItemToInventory(string nameOfItem, int amountOfItem, Sprite iconOfItem)
        {
            if (currentInventoryData.Exists(x => x.inventoryItemName == nameOfItem))
            {

                for (int i = 0; i < currentInventoryData.Count; i++)
                {
                    if (currentInventoryData[i].inventoryItemName == nameOfItem)
                    {
                        CurrentInventoryData tempData = currentInventoryData[i];
                        tempData.inventoryItemCounter = amountOfItem;
                        currentInventoryData[i] = tempData;
                        inventoryCounterText[i].text =
                            "x" + currentInventoryData[i].inventoryItemCounter.ToString("00");
                    }
                }
            }
            else
            {
                for (int i = 0; i < currentInventoryData.Count; i++)
                {
                    if (string.IsNullOrEmpty(currentInventoryData[i].inventoryItemName))
                    {
                        CurrentInventoryData tempData = currentInventoryData[i];
                        tempData.inventoryItemName = nameOfItem;
                        tempData.inventoryItemCounter = amountOfItem;
                        tempData.inventoryItemIcon = iconOfItem;
                        currentInventoryData[i] = tempData;
                        inventoryItemImageSlot[i].sprite = currentInventoryData[i].inventoryItemIcon;
                        inventoryCounterText[i].text =
                            "x" + currentInventoryData[i].inventoryItemCounter.ToString("00");
                        inventoryItemNameText[i].text = currentInventoryData[i].inventoryItemName;

                        Debug.Log($"Added {nameOfItem} to inventory. Count: {amountOfItem}");
                        StartCoroutine(ManagingInventory());
                        break; 
                    }
                }
            }
        }

        private IEnumerator ManagingInventory()
            {
                for (int i = 0; i < currentInventoryData.Count; i++)
                {
                    if (currentInventoryData[i].inventoryItemCounter != 0)
                    {
                        inventorySlots[i].GetComponent<CanvasGroup>().alpha = 1;
                    }
                    else 
                        inventorySlots[i].GetComponent<CanvasGroup>().alpha = 0;
                }

                yield break;
            }
    }
}


