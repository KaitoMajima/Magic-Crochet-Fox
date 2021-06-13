using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KaitoMajima
{
    public class PinballingMode : MonoBehaviour
    {
        [SerializeField] private int fixedDamage;
        [SerializeField] private Rigidbody2D bodyRigidBody;

        [SerializeField] private float minVelocityToDamage;
        public static Action onPinballCount;

        public UnityEvent onPinballHit;

        public UnityEvent onPinballArmedFire;
        public UnityEvent onPinballArmedRelease;
        
        private bool isPinballArmed;
        private bool wasPinballArmed;
        public bool activated = false;


        public void Activate(bool condition)
        {
            activated = condition;
        }

        private void Update()
        {
            if(!activated)
                return;
            
            if(bodyRigidBody.velocity.magnitude > minVelocityToDamage)
            {
                isPinballArmed = true;
                if(!wasPinballArmed && isPinballArmed)
                {
                    onPinballArmedFire?.Invoke();
                    wasPinballArmed = true;
                }
            }

            if(bodyRigidBody.velocity.magnitude < minVelocityToDamage)
            {
                isPinballArmed = false;
                if(wasPinballArmed && !isPinballArmed)
                {
                    onPinballArmedRelease?.Invoke();
                    wasPinballArmed = false;
                }
            }    
            


        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(!activated)
                return;
            
            if(col.isTrigger)
                return;
            
            if(bodyRigidBody.velocity.magnitude < minVelocityToDamage)
                return;
            

            if(!col.TryGetComponent(out EnemyHealth enemyHealth))
                return;
            
            if(col.TryGetComponent(out PinballingMode pinballer))
            {
                if(pinballer.activated)
                    return;
            }
            onPinballCount?.Invoke();
            onPinballHit?.Invoke();
            enemyHealth.Damage(fixedDamage);
        }
    }
}
