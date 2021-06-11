using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class TriggerGameWon : MonoBehaviour
    {
        public void Call()
        {
            GameManager.OnGameWon?.Invoke();
        }
    }
}
