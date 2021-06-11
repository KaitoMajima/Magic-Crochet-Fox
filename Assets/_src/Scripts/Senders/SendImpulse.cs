using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace KaitoMajima
{
    public class SendImpulse : MonoBehaviour
    {
        [SerializeField] private CinemachineImpulseSource impulseSource;
        
        [SerializeField] private bool playOnAwake;
        private void Awake()
        {
            if(playOnAwake)
                TriggerImpulse();
        }
        public void TriggerImpulse()
        {
            impulseSource.GenerateImpulse(Vector2.up);
        }

    }
}
