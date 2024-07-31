using System;
using System.Collections;
using UnityEngine;
using DarkShadowHunter;
using TMPro;

public class FinalSpawnScript : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [TagSelector] [SerializeField] private string thisTage;
    [SerializeField] private GameObject _text;

    private void Awake()
    {
        _text.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(thisTage))
        {
            Debug.Log("Hit Player");
            TransportPlayer();
        }
    }
    
    private void TransportPlayer()
    {
        if (PlayerScript._controller != null)
        {
            Debug.Log("Transporting player to destination: " + destination.position);

            // Check if the player has a CharacterController
            CharacterController characterController = PlayerScript._controller.GetComponent<CharacterController>();
            if (characterController != null)
            {
                StartCoroutine(TeleportCharacterController(characterController));
            }
            else
            {
                Debug.LogError("Player does not have a CharacterController component.");
            }
        }
        else
        {
            Debug.LogError("PlayerScript._controller is null. Cannot transport player.");
        }
    }

    private IEnumerator TeleportCharacterController(CharacterController characterController)
    {
        // Disable the CharacterController before setting the position
        characterController.enabled = false;

        // Set the new position
        PlayerScript._controller.transform.position = destination.position;

        // Wait for one frame to ensure the position is set
        yield return null;
        
        _text.SetActive(true);

        Debug.Log("Player teleported to: " + PlayerScript._controller.transform.position);
    }
}
