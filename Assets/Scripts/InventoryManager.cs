using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DarkShadowHunter
{
    public class InventoryManager : MonoBehaviour
    {
        [Header("Inventory Screen")]
        [SerializeField] private GameObject inventoryScreen;
        [Header("Slots Of The Inventory")]
        [SerializeField] private GameObject[] inventorySlots;
        [Header("Inventory Item Icons")]
        [SerializeField] private Sprite[] inventoryItemIcons;
        [Header("Inventory Item Image Slot Control")]
        [SerializeField] private GameObject[] inventoryItemImageSlotGameObject;
        [SerializeField] private Image[] inventoryItemImageSlot;
        [Header(("Inventory Item Name Text Control"))]
        [SerializeField] private GameObject[] inventoryItemNameGameObject;
        [SerializeField] private TextMeshProUGUI[] inventoryItemNameText;
        [Header("Inventory Item Counter Text Control")]
        [SerializeField] private GameObject[] inventoryCounterGameObject;
        [SerializeField] private TextMeshProUGUI[] inventoryCounterText;
        

        private int _allInventoryItemCounter;
        private string _inventoryOneName,
            _inventoryTwoName,
            _inventoryThreeName,
            _inventoryFourName,
            _inventoryFiveName,
            _inventorySixName,
            _inventorySevenName,
            _inventoryEightName,
            _inventoryNineName;

        private int _inventoryOneCounter,
            _inventoryTwoCounter,
            _inventoryThreeCounter,
            _inventoryFourCounter,
            _inventoryFiveCounter,
            _inventorySixCounter,
            _inventorySevenCounter,
            _inventoryEightCounter,
            _inventoryNineCounter;

        private int _buttonToOpenCounter = 0;


        private void Awake()
        {
            _allInventoryItemCounter = 0;
            _buttonToOpenCounter = 0;
            foreach (var t in inventoryCounterText)
            {
                t.text = "0";
            }

            foreach (var t in inventoryItemNameText)
            {
                t.text = "";
            }

            foreach (var tg in inventoryItemNameGameObject)
            {
                tg.SetActive(false);
            }

            foreach (var tg in inventoryCounterGameObject)
            {
                tg.SetActive(false);
            }
            foreach (var s in inventorySlots)
            {
                s.SetActive(false);
            }
            inventoryScreen.SetActive(false);
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
            inventoryScreen.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            if (_inventoryOneCounter > 0)
            {
                inventorySlots[0].SetActive(true);
                inventoryItemNameGameObject[0].SetActive(true);
                inventoryCounterGameObject[0].SetActive(true);
                inventoryItemNameText[0].text = "x" + _inventoryOneCounter.ToString("00");
                _inventoryOneName = inventoryItemNameText[0].text;
            }
            else
            {
                inventorySlots[0].SetActive(false);
                
            }
            if (_inventoryTwoCounter > 0)
            {
                inventorySlots[1].SetActive(true);
                inventoryItemNameGameObject[1].SetActive(true);
                inventoryCounterGameObject[1].SetActive(true);
                inventoryItemNameText[1].text = "x" + _inventoryTwoCounter.ToString("00");
                _inventoryTwoName = inventoryItemNameText[1].text;
            }
            else
            {
                inventorySlots[1].SetActive(false);
            }
            if (_inventoryThreeCounter > 0)
            {
                inventorySlots[2].SetActive(true);
                inventoryItemNameGameObject[2].SetActive(true);
                inventoryCounterGameObject[2].SetActive(true);
                inventoryItemNameText[2].text = "x" + _inventoryThreeCounter.ToString("00");
                _inventoryThreeName = inventoryItemNameText[2].text;
            }
            else
            {
                inventorySlots[2].SetActive(false);
            }
            if (_inventoryFourCounter > 0)
            {
                inventorySlots[3].SetActive(true);
                inventoryItemNameGameObject[3].SetActive(true);
                inventoryCounterGameObject[3].SetActive(true);
                inventoryItemNameText[3].text = "x" + _inventoryFourCounter.ToString("00");
                _inventoryFourName = inventoryItemNameText[3].text;
            }
            else
            {
                inventorySlots[3].SetActive(false);
            }
            if (_inventoryFiveCounter > 0)
            {
                inventorySlots[4].SetActive(true);
                inventoryItemNameGameObject[4].SetActive(true);
                inventoryCounterGameObject[4].SetActive(true);
                inventoryItemNameText[4].text = "x" + _inventoryFiveCounter.ToString("00");
                _inventoryFiveName = inventoryItemNameText[4].text;
            }
            else
            {
                inventorySlots[4].SetActive(false);
            }
            if (_inventorySixCounter > 0)
            {
                inventorySlots[5].SetActive(true);
                inventoryItemNameGameObject[5].SetActive(true);
                inventoryCounterGameObject[5].SetActive(true);
                inventoryItemNameText[5].text = "x" + _inventorySixCounter.ToString("00");
                _inventorySixName = inventoryItemNameText[5].text;
            }
            else
            {
                inventorySlots[5].SetActive(false);
            }
            if (_inventorySevenCounter > 0)
            {
                inventorySlots[6].SetActive(true);
                inventoryItemNameGameObject[6].SetActive(true);
                inventoryCounterGameObject[6].SetActive(true);
                inventoryItemNameText[6].text = "x" + _inventorySevenCounter.ToString("00");
                _inventorySevenName = inventoryItemNameText[6].text;
            }
            else
            {
                inventorySlots[6].SetActive(false);
            }
            if (_inventoryEightCounter > 0)
            {
                inventorySlots[7].SetActive(true);
                inventoryItemNameGameObject[7].SetActive(true);
                inventoryCounterGameObject[7].SetActive(true);
                inventoryItemNameText[7].text = "x" + _inventoryEightCounter.ToString("00");
                _inventoryEightName = inventoryItemNameText[7].text;
            }
            else
            {
                inventorySlots[7].SetActive(false);
            }
            if (_inventoryNineCounter > 0)
            {
                inventorySlots[8].SetActive(true);
                inventoryItemNameGameObject[8].SetActive(true);
                inventoryCounterGameObject[8].SetActive(true);
                inventoryItemNameText[8].text = "x" + _inventoryNineCounter.ToString("00");
                _inventoryNineName = inventoryItemNameText[8].text;
            }
            else
            {
                inventorySlots[8].SetActive(false);
            }
        }
        
        private IEnumerator CloseInventory()
        {
            foreach (var s in inventorySlots)
            {
                s.SetActive(false);
            }
            foreach (var tg in inventoryItemNameGameObject)
            {
                tg.SetActive(false);
            }
            foreach (var tg in inventoryCounterGameObject)
            {
                tg.SetActive(false);
            }
            inventoryScreen.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
    }

}
