using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

namespace KaitoMajima
{
    public class SendAudio : MonoBehaviour
    {
        
        private ISound sound;

        [InfoBox("This Game Object needs a component that implements the ISound interface.")]

        [SerializeField]
        private bool spawnSound;

        private void Awake()
        {
            if(!TryGetComponent(out sound))
                Debug.LogWarning("No audio is attached to this Game Object! Send Audio will not work.");
        }

        public void TriggerSound()
        {
            if(spawnSound)
            {
                try
                {
                    var soundObj = (this.sound as Component).gameObject;
                    var spawnedSoundObj = Instantiate(soundObj, soundObj.transform.position, Quaternion.identity);
                    var sound = spawnedSoundObj.GetComponent<ISound>();
                    sound.Play();
                }
                catch (System.NullReferenceException)
                {
                    
                }
                
                
            }
            else
                sound.Play();
        }

    }
}
