using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DarkShadowHunter
{
    public class PotionCraftTable : Interatable
    {
        private PlayerScript _player;
        [SerializeField] private GameObject _Prompt;
        [SerializeField] private GameObject _craftCanvas;
        [SerializeField] private Camera _mainCam;
        private bool _isCrafting;
        // Start is called before the first frame update
        void Start()
        {
            _mainCam = GameObject.Find("CharacterCam").GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_player!=null)
            {
                BillboardForPrompt();
                Interact();
            }
            else
            {
                MenuSwitch(false);//will close menu if too far from player
                _isCrafting = false;
            }
        }

        public override void Interact()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                MenuSwitch();
                _player.PauseSwitch();
            }
        }

        private void MenuSwitch()
        {
            _craftCanvas.SetActive(!_isCrafting);
            _isCrafting = !_isCrafting;
            if (_isCrafting)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        private void MenuSwitch(bool inputBool)
        {
            _craftCanvas.SetActive(inputBool);
            _isCrafting = inputBool;
            if (_isCrafting)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerScript>(out _player))
            {
                _Prompt.SetActive(true);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<PlayerScript>(out _player))
            {
                _player.PauseSwitch(false);
                _player = null;
                _Prompt.SetActive(false);
             }
        }

        private void BillboardForPrompt()
        {
            _Prompt.transform.rotation =_mainCam.transform.rotation;
        }
    }
}
