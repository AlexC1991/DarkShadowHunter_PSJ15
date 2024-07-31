using System;
using System.Collections;
using UnityEngine;

public class HQSoundScript : MonoBehaviour
{
    [SerializeField] ScriptableAudioFile labSound;
    [SerializeField] private float visionRadius = 1;
    [SerializeField] private GameObject player;
    private Vector3 playerCoordinates;

    private void Start()
    {
        StartCoroutine(PlayMusic());
    }

    public IEnumerator PlayMusic()
    {
            if (PlayerIsClose())
            {
                labSound.PlayAudio();
            }
            if (PlayerIsClose() && labSound.audioSource.isPlaying)
            {
                labSound.audioSource.volume = 0.01f;
            }
            else
            {
                labSound.StopAudio();
            }
            yield break;
    }
    
    
    private bool PlayerIsClose()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < visionRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
