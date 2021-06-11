using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class ReceiveGameWon : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        private void Start()
        {
            GameManager.OnGameWon += TriggeredGameWon;
        }

        private void TriggeredGameWon()
        {   
            target.SetActive(true);
        }

        private void OnDestroy()
        {
            GameManager.OnGameWon -= TriggeredGameWon;
        }
    }
}
