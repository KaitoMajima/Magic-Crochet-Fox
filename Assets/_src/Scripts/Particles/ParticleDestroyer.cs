using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class ParticleDestroyer : MonoBehaviour
    {
        public enum DestructionType
        {
            ParticlesDeath,
            Duration
        }
        public enum DestructionTarget
        {
            ParticleGameObject,
            ScriptGameObject
        }
        [SerializeField] private DestructionType destructionType;

        [SerializeField] private DestructionTarget destructionTarget;
        [SerializeField] private ParticleSystem objParticleSystem;
        private float durationTimer;

        private void Start()
        {
            if (destructionType == DestructionType.Duration)
                StartCoroutine(RunThroughDuration(objParticleSystem.main.duration));
        }
        private void Update()
        {

            if(destructionType != DestructionType.ParticlesDeath)
                return;

            if (!objParticleSystem.IsAlive())
                DestroyTarget();
        }

        private void DestroyTarget()
        {
            if(destructionTarget == DestructionTarget.ParticleGameObject)
            {
                Destroy(objParticleSystem.gameObject);
                Destroy(this);
            }
            else
                Destroy(gameObject);
                
        }
        private IEnumerator RunThroughDuration(float duration)
        {
            durationTimer = duration;

            while (true)
            {
                durationTimer -= Time.deltaTime;
                if (durationTimer < 0) break;
                yield return null;
            }
            DestroyTarget();
        }
    }

}
