using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager Instance {get; private set;}
        private ISound currentMusic;
        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(this);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        public void SetMusic(ISound source)
        {
            try
            {
                if(currentMusic != null)
                    currentMusic.Stop();
            }
            catch (UnityEngine.MissingReferenceException)
            {
                
            }
            currentMusic = source;
        }
        public void Play()
        {
            currentMusic.Play();
        }
        public void Stop()
        {
            currentMusic.Stop();
        }
    }
}
