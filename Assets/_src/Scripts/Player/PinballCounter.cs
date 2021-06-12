using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class PinballCounter : MonoBehaviour
    {
        [SerializeField] private float minTimer;

        private int comboCount;

        private float comboTimer;

        private Coroutine reseter;

        private void Start()
        {
            PinballingMode.onPinballCount += AddCombo;
        }

        private void AddCombo()
        {
            comboCount++;
            if(reseter != null)
                StopCoroutine(reseter);
            reseter = StartCoroutine(ComboReseter());
        }

        private IEnumerator ComboReseter()
        {
            comboTimer = minTimer;

            while (comboTimer > 0)
            {
                comboTimer -= Time.deltaTime;
                yield return null;
            }
            comboTimer = 0;
            comboCount = 0;
        }

        private void OnDestroy()
        {
            PinballingMode.onPinballCount -= AddCombo;
        }
    }
}
