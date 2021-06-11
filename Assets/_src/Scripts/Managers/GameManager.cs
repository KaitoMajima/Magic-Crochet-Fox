using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace KaitoMajima
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get; private set;}

        public static Action OnGameOver;
        public static Action OnGameWon;
        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
