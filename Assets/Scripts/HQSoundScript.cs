using System.Collections;
using UnityEngine;

public class HQSoundScript : MonoBehaviour
{
    [SerializeField] private ScriptableAudioFile hqMusic;
    [SerializeField] private float visionRadius = 1;
    [SerializeField] private GameObject player;
    private Coroutine musicCoroutine;

    private void Start()
    {
        musicCoroutine = StartCoroutine(CheckPlayerDistance());
    }

    private IEnumerator CheckPlayerDistance()
    {
        while (true)
        {
            bool playerClose = PlayerIsInCircle();

            if (playerClose)
            {
                if (hqMusic.audioSource == null || !hqMusic.audioSource.isPlaying)
                {
                    PlayMusic();
                }
            }
            else if (!playerClose)
            {
                if (hqMusic.audioSource != null && hqMusic.audioSource.isPlaying)
                {
                    StopMusic();
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private bool PlayerIsInCircle()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        return distance < visionRadius;
    }

    private void PlayMusic()
    {
        Debug.Log("Playing music");
        hqMusic.PlayAudio();
        hqMusic.volume = 0.01f;
    }

    private void StopMusic()
    {
        Debug.Log("Stopping music");
        hqMusic.StopAudio();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
