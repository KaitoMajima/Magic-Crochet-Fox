using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class ReceiveGameOver : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        private void Start()
        {
            GameManager.OnGameOver += TriggeredGameOver;
        }

        private void TriggeredGameOver()
        {   
            target.SetActive(true);
        }

        private void OnDestroy()
        {
            GameManager.OnGameOver -= TriggeredGameOver;
        }
    }
}
