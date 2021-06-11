using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace KaitoMajima
{
    public class NextSelectedButton : MonoBehaviour
    {
        [SerializeField] private GameObject nextSelectedButton;
        public void Connect()
        {
            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(nextSelectedButton);
        }
        
        public void SetButton(GameObject obj)
        {
            nextSelectedButton = obj;
        }
        
    }
}
