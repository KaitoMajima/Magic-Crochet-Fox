using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KaitoMajima
{
    public class EnemyHealth : MonoBehaviour
    {
        private Coroutine currentCoroutine;

        [SerializeField] private HealthState healthState = HealthState.Default;

        [SerializeField] private float drainingInterval = 0.25f;
        [SerializeField] private int drainingRate = 4;
        [SerializeField] private float refillingInterval = 0.45f;
        [SerializeField] private int refillingRate = 3;


        public UnityEvent onDrainStart;
        public UnityEvent onRefiilFinish;
        public UnityEvent onDamage;
        public Action<HealthState> onHealthChanged;

        public UnityEvent onEnemyDeath;

        public void StartDraining()
        {
            if(currentCoroutine != null)
                StopCoroutine(currentCoroutine);
            
            currentCoroutine = StartCoroutine(Drain());
        }

        public void StartRefilling()
        {
            if(currentCoroutine != null)
                StopCoroutine(currentCoroutine);
            
            currentCoroutine = StartCoroutine(Refill());
        }

        public void Damage(int amount)
        {
            onDamage?.Invoke();
            healthState.Health -= amount;
            if(healthState.Health <= 0)
                healthState.Health = 1;
            
            onHealthChanged?.Invoke(healthState);
        }
        private IEnumerator Drain()
        {
            onDrainStart?.Invoke();
            while (healthState.Health > 0)
            {
                healthState.Health -= drainingRate;
                onHealthChanged?.Invoke(healthState);
                yield return new WaitForSeconds(drainingInterval);
            }
            if(healthState.Health < 0)
                healthState.Health = 0;
            Die();
        }

        private IEnumerator Refill()
        {
            while (healthState.Health < healthState.MaxHealth)
            {
                healthState.Health -= refillingRate;
                onHealthChanged?.Invoke(healthState);
                yield return new WaitForSeconds(refillingInterval);
            }

            if(healthState.Health > healthState.MaxHealth)
                healthState.Health = healthState.MaxHealth;
            
            onRefiilFinish?.Invoke();
        }

        public void Die()
        {
            onEnemyDeath?.Invoke();
            NeedleShooter.onRetrieveNeedle?.Invoke();
            Destroy(gameObject);

        }
    }
}
