using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KaitoMajima
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private GameObject doorObj;

        public UnityEvent onDoorLock;
        public UnityEvent onDoorUnlock;
        public void Lock()
        {
            doorObj.SetActive(true);
            onDoorLock?.Invoke();
        }

        public void Unlock()
        {
            doorObj.SetActive(false);
            onDoorUnlock?.Invoke();

        }

        public void Switch(bool state)
        {
            doorObj.SetActive(!state);
        }
    }
}
