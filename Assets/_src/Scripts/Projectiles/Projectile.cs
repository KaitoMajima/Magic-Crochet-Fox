using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace KaitoMajima
{
    public class Projectile : MonoBehaviour
    {
        [ReadOnly] public Transform originalHolder; 
        [SerializeField] private Rigidbody2D projRigidBody;
        [SerializeField] private float speed = 10;
        [SerializeField] private float maxAliveTime = 1;

        [SerializeField] private SendAudio initialSound;

        private bool hasQueuedExplosion;

        private float aliveTimer;
        private Coroutine aliveCoroutine;

        public Action<ProjectileContactData> onProjectileContact;

        public UnityEvent onProjectileExplosion;

        public UnityEvent onProjectileHit;


        private void Start()
        {
            aliveCoroutine = StartCoroutine(StartAliveTimer(maxAliveTime));
            projRigidBody.AddForce(speed * transform.right, ForceMode2D.Impulse);

            initialSound?.TriggerSound();
        }

        private IEnumerator StartAliveTimer(float seconds)
        {
            aliveTimer = seconds;

            while (aliveTimer > 0)
            {
                aliveTimer -= Time.deltaTime;
                yield return null;
            }

            NeedleShooter.onRetrieveNeedle?.Invoke();
            Explode();
        }

        private void Explode()
        {
            hasQueuedExplosion = true;
            Destroy(gameObject);
            onProjectileExplosion?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.isTrigger)
                return;
            
            if(col.TryGetComponent(out ProjectileCollisionIgnorer projIgnorer))
            {
                if(projIgnorer.activated)
                {
                    if(projIgnorer.explodeOnImpact)
                    {
                        NeedleShooter.onRetrieveNeedle?.Invoke();
                        StopCoroutine(aliveCoroutine);
                        Explode();
                        
                    }
                        
                    return;
                }
                    
            }
            if(hasQueuedExplosion)
                return;

            var projData = new ProjectileContactData(originalHolder, col.transform);
            onProjectileContact?.Invoke(projData);
            onProjectileHit?.Invoke();
            Explode();
        }

        public class ProjectileContactData
        {
            public Transform originalHolder;
            public Transform targetHit;

            public ProjectileContactData(Transform originalHolder, Transform targetHit)
            {
                this.originalHolder = originalHolder;
                this.targetHit = targetHit;
            }
        }
    }
}
