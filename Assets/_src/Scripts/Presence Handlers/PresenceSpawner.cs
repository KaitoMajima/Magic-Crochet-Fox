using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class PresenceSpawner : MonoBehaviour
    {
        [SerializeField] private PresenceDetect presenceDetect;
        [SerializeField] private EnemySpawner enemySpawner;
        public Action<List<GameObject>> onEnemiesSpawned;

        private void Start()
        {
            presenceDetect.onPresenceDetected += TriggerSpawner;
        }

        private void TriggerSpawner()
        {
            List<GameObject> enemies = enemySpawner.TrySpawn();
            if(enemies == null)
                return;
            
            onEnemiesSpawned?.Invoke(enemies);
        }

        private void OnDestroy()
        {
            presenceDetect.onPresenceDetected -= TriggerSpawner;
        }
    }
}
