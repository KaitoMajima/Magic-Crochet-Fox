using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KaitoMajima
{
    public class RadialTimer : MonoBehaviour
    {
        [SerializeField] private EnemyHealth enemyHealth;
        [SerializeField] private Image image;

        private void Awake()
        {
            enemyHealth.onHealthChanged += ChangeTimer;
        }

        private void ChangeTimer(HealthState healthState)
        {
            image.fillAmount = (float)healthState.Health / healthState.MaxHealth;
        }

        private void OnDestroy()
        {
            enemyHealth.onHealthChanged -= ChangeTimer;
        }
    }
}
