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

        private float aliveTimer;
        private Coroutine aliveCoroutine;

        public Action<ProjectileContactData> onProjectileContact;

        public UnityEvent onProjectileExplosion;

        private void Start()
        {
            aliveCoroutine = StartCoroutine(StartAliveTimer(maxAliveTime));
            projRigidBody.AddForce(speed * transform.right, ForceMode2D.Impulse);
        }

        private IEnumerator StartAliveTimer(float seconds)
        {
            aliveTimer = seconds;

            while (aliveTimer > 0)
            {
                aliveTimer -= Time.deltaTime;
                yield return null;
            }

            Explode();
        }

        private void Explode()
        {
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
                        Explode();
                    return;
                }
                    
            }
                    
            var projData = new ProjectileContactData(originalHolder, col.transform);
            onProjectileContact?.Invoke(projData);
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
