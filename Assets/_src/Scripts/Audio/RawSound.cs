using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class RawSound : MonoBehaviour, ISound
    {
        [SerializeField] private bool playOnAwake;
        [SerializeField] private bool oneShot;
        [SerializeField] private bool autoDestruct;
        [SerializeField] private AudioSource audioSource;

        private void Awake()
        {
            if(playOnAwake)
                Play();
        }
        public void Play()
        {
            audioSource.Play();
            
            if(oneShot)
                audioSource.PlayOneShot(audioSource.clip);
            else
                audioSource.Play();
            
            if(autoDestruct)
                Destroy(gameObject, audioSource.clip.length);
        }
        
        public void Stop()
        {
            audioSource.Stop();
        }
    }
}
