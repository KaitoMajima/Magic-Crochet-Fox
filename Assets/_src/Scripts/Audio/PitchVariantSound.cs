using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class PitchVariantSound : MonoBehaviour, ISound
    {
        [SerializeField] private bool playOnAwake;
        [SerializeField] private bool oneShot;
        [SerializeField] private bool autoDestruct;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Vector2 pitchRange = Vector2.one;

        private void Awake()
        {
            if(playOnAwake)
                Play();
        }

        public void Play()
        {
            audioSource.pitch = Random.Range(pitchRange.x, pitchRange.y);
            if(oneShot)
                audioSource.PlayOneShot(audioSource.clip);
            else
                audioSource.Play();

            if(autoDestruct)
                StartCoroutine(DestroyWhenFinished(audioSource, gameObject));
        }

        public void Stop()
        {
            audioSource.Stop();
        }
        private IEnumerator DestroyWhenFinished(AudioSource source, GameObject destroyed)
        {
            while(source.isPlaying)
            {
                yield return null;
            }
            Destroy(destroyed);
        }
    }
}
