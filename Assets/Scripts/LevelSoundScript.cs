using System.Collections;
using UnityEngine;

namespace DarkShadowHunter
{
    public class LevelSoundScript : MonoBehaviour
    {
        [SerializeField] private ScriptableAudioFile levelMusic;
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
                    if (levelMusic.audioSource == null || !levelMusic.audioSource.isPlaying)
                    {
                        PlayMusic();
                    }
                }
                else if (!playerClose)
                {
                    if (levelMusic.audioSource != null && levelMusic.audioSource.isPlaying)
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
            levelMusic.PlayAudio();
            levelMusic.volume = 0.01f;
        }

        private void StopMusic()
        {
            Debug.Log("Stopping music");
            levelMusic.StopAudio();
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, visionRadius);
        }
    }

}
