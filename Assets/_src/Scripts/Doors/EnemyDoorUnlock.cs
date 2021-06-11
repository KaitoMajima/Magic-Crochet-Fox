using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class EnemyDoorUnlock : MonoBehaviour
    {
        private List<GameObject> enemies = new List<GameObject>();
        [SerializeField] private PresenceSpawner enemySpawner;   
        [SerializeField] private Door[] theDoors;
        private void Start()
        {
            enemySpawner.onEnemiesSpawned += PopulateEnemies;
        }
        private void Update()
        {
            if(enemies.Count == 0)
                return;

            EnemiesCheck();
        }

        private void EnemiesCheck()
        {

            for (int i = 0; i < enemies.Count; i++)
            {
                if(!enemies[i])
                    enemies.RemoveAt(i);
            }

            if(enemies.Count > 0)
                return; 
            
            foreach (var door in theDoors)
            {
                door.Unlock();
            }        
                
        }
        public void PopulateEnemies(List<GameObject> obj)
        {
            enemies = obj;
        }

        private void OnDestroy()
        {
            enemySpawner.onEnemiesSpawned -= PopulateEnemies;
        }
    }
}
