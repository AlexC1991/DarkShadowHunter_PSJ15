using System;
using TMPro;
using UnityEngine;

namespace DarkShadowHunter
{
    public class PlayerPickupScript : MonoBehaviour
    {
        private Ray _infoRay;
        [TagSelector] public string[] tagToPickupOnly;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private TextMeshProUGUI _pickUpText;
        private GameObject _hitObject;
        private string _tagOptionOne;
        private string _tagOptionTwo;
        private string _tagOptionThree;
        private string _tagOptionFour;

        private void Start()
        {
            _pickUpText.text = "";
            
            _tagOptionOne = tagToPickupOnly[0];
            _tagOptionTwo = tagToPickupOnly[1];
            _tagOptionThree = tagToPickupOnly[2];
            _tagOptionFour = tagToPickupOnly[3];
            
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
                Debug.Log("Tried to pick up " + itemName);
                Destroy(_hitObject);
                _pickUpText.text = "";
            }
        }
        
    }
}
