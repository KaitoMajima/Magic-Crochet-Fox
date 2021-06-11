using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class PresenceDetect : MonoBehaviour
    {
        public Action onPresenceDetected;
        public Action onPresenceLost;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.isTrigger)
                return;
            if(!collider.TryGetComponent(out Player player))
                return;

            onPresenceDetected?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if(collider.isTrigger)
                return;
            if(!collider.TryGetComponent(out Player player))
                return;
            
            onPresenceLost?.Invoke();
        }
    }
}
