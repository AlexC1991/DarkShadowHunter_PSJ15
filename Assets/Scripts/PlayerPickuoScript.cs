using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace DarkShadowHunter
{
    public class PlayerPickupScript : MonoBehaviour
    {
        private Ray _infoRay;
        [SerializeField] private InventoryManager _inventoryM;
        [SerializeField] private InventoryDataContainer _iDC;
        [TagSelector] public string[] tagToPickupOnly;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private TextMeshProUGUI _pickUpText;
        private GameObject _hitObject;
        private string _tagOptionOne;
        private string _tagOptionTwo;
        private string _tagOptionThree;
        private string _tagOptionFour;

        private void Awake()
        {
           for (int i = 0; i < _iDC.inventoryData.Length; i++)
           {
               _iDC.inventoryData[i].inventoryItemCounter = 0;
           }
        }

        private void Start()
        {
            if (_inventoryM == null || _iDC == null)
            {
                Debug.LogError("Inventory Manager or Inventory Data Container is not assigned.");
                return;
            }

            _pickUpText.text = "";

            if (tagToPickupOnly.Length >= 4)
            {
                _tagOptionOne = tagToPickupOnly[0];
                _tagOptionTwo = tagToPickupOnly[1];
                _tagOptionThree = tagToPickupOnly[2];
                _tagOptionFour = tagToPickupOnly[3];
            }
            else
            {
                Debug.LogError("Insufficient tags assigned to tagToPickupOnly.");
            }
        }

        private void Update()
        {
            if (_mainCamera == null || _pickUpText == null)
            {
                Debug.LogError("Main Camera or Pickup Text is not assigned.");
                return;
            }

            _infoRay = _mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            try
            {
                if (Physics.Raycast(_infoRay, out hit, 2))
                {
                    _hitObject = hit.collider.gameObject;

                    if (_hitObject != null)
                    {
                        string objectTag = _hitObject.tag;
                        Debug.Log("Hit Object: " + _hitObject.name + " with Tag: " + objectTag);

                        if (_hitObject.CompareTag(_tagOptionOne))
                        {
                            HandlePickup(_tagOptionOne);
                        }
                        else if (_hitObject.CompareTag(_tagOptionTwo))
                        {
                            HandlePickup(_tagOptionTwo);
                        }
                        else if (_hitObject.CompareTag(_tagOptionThree))
                        {
                            HandlePickup(_tagOptionThree);
                        }
                        else if (_hitObject.CompareTag(_tagOptionFour))
                        {
                            HandlePickup(_tagOptionFour);
                        }
                        else
                        {
                            _pickUpText.text = "";
                        }
                    }
                    else
                    {
                        _pickUpText.text = "";
                    }
                }
                else
                {
                    _pickUpText.text = "";
                }
            }
            catch (System.NullReferenceException ex)
            {
                Debug.LogError("NullReferenceException: " + ex.Message);
            }
        }
        
        private void HandlePickup(string itemName)
        {
            Debug.Log("Found " + itemName);
            _pickUpText.text = "Press E to pick up " + itemName;

            if (Input.GetKeyDown(KeyCode.E) && _hitObject != null)
            {
                if (_hitObject.CompareTag(_tagOptionOne))
                {
                    StartCoroutine(AddAshToInventory());
                    Destroy(_hitObject);
                    _pickUpText.text = "";
                }
                else if (_hitObject.CompareTag(_tagOptionTwo))
                {
                    StartCoroutine(AddBeadToInventory());
                    Destroy(_hitObject);
                    _pickUpText.text = "";
                }
                else if (_hitObject.CompareTag(_tagOptionThree))
                {
                    StartCoroutine(AddResidueToInventory());
                    Destroy(_hitObject);
                    _pickUpText.text = "";
                }
                else if (_hitObject.CompareTag(_tagOptionFour))
                {
                    StartCoroutine(AddFleshToInventory());
                    Destroy(_hitObject);
                    _pickUpText.text = "";
                }
            }
        }

        private IEnumerator AddAshToInventory()
        {
            _iDC.inventoryData[0].inventoryItemCounter += 1;
            _inventoryM.AddItemToInventory(_iDC.inventoryData[0].inventoryItemName, _iDC.inventoryData[0].inventoryItemCounter, _iDC.inventoryData[0].inventoryItemSprite);
            yield break;
        }
        
        private IEnumerator AddBeadToInventory()
        {
            _iDC.inventoryData[1].inventoryItemCounter += 1;
            _inventoryM.AddItemToInventory(_iDC.inventoryData[1].inventoryItemName, _iDC.inventoryData[1].inventoryItemCounter, _iDC.inventoryData[1].inventoryItemSprite);
            yield break;
        }
        
        private IEnumerator AddResidueToInventory()
        {
            _iDC.inventoryData[2].inventoryItemCounter += 1;
            _inventoryM.AddItemToInventory(_iDC.inventoryData[2].inventoryItemName, _iDC.inventoryData[2].inventoryItemCounter, _iDC.inventoryData[2].inventoryItemSprite);
            yield break;
        }
        
        private IEnumerator AddFleshToInventory()
        {
            _iDC.inventoryData[3].inventoryItemCounter += 1;
            _inventoryM.AddItemToInventory(_iDC.inventoryData[3].inventoryItemName, _iDC.inventoryData[3].inventoryItemCounter, _iDC.inventoryData[3].inventoryItemSprite);
            yield break;
        }
    }
}
