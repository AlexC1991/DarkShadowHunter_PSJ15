using System;
using System.Collections;
using UnityEngine;

namespace DarkShadowHunter
{
    public class ShadowMinonAIScript : MonoBehaviour
    {
        [SerializeField] ScriptableAudioFile fightSong;
        [SerializeField] private float visionRadius = 1;
        [SerializeField] private GameObject player;
        private Vector3 playerCoordinates;
        private Coroutine monsterCoroutine;

        private void Start()
        {
            monsterCoroutine = StartCoroutine(CheckPlayerDistance());
        }
        
        private IEnumerator CheckPlayerDistance()
        {
            while (true)
            {
                bool playerClose = BattlingShadowMonster();

                if (playerClose)
                {
                    if (fightSong.audioSource == null || !fightSong.audioSource.isPlaying)
                    {
                        PlayMusic();
                    }
                }
                else if (!playerClose)
                {
                    if (fightSong.audioSource != null && fightSong.audioSource.isPlaying)
                    {
                        StopMusic();
                    }
                }

                yield return new WaitForSeconds(0.5f);
            }
        }

        public bool BattlingShadowMonster()
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

        public IEnumerator PlayMusic()
        {
            fightSong.PlayAudio();
            fightSong.volume = 0.01f;
            yield break;
        }

        public IEnumerator StopMusic()
        {
            fightSong.StopAudio();
            yield break;
        }
    }
}
