using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KaitoMajima
{
    public class SetMusic : SerializedMonoBehaviour
    {
        private MusicManager musicManager;
        [SerializeField] private ISound music;

        [SerializeField] private bool playOnStart;

        private void Start()
        {
            musicManager = MusicManager.Instance;

            if(playOnStart)
                Change();
                
        }

        public void Change()
        {
            musicManager.SetMusic(music);
        }
    }
}
