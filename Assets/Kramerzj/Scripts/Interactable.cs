using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Unity.FPS.Gameplay
{
    public class Interactable : MonoBehaviour
    {
        private PlayerInputHandler player;
        [SerializeField] private GameObject Prompt;
        private Camera mainCam;
        // Start is called before the first frame update
        void Start()
        {
            mainCam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (player!=null)
            {
                BillboardForPrompt();
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerInputHandler>(out player))
            {
                Prompt.SetActive(true);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<PlayerInputHandler>(out player))
            {
                player = null;
                Prompt.SetActive(false);
            }
        }

        private void BillboardForPrompt()
        {
            Prompt.transform.rotation =mainCam.transform.rotation;
        }
    }
}
