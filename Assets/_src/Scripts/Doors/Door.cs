using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private GameObject doorObj;

        public void Lock()
        {
            doorObj.SetActive(true);
        }

        public void Unlock()
        {
            doorObj.SetActive(false);
        }

        public void Switch(bool state)
        {
            doorObj.SetActive(!state);
        }
    }
}
