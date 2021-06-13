using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enemyPrefab;
        [SerializeField] private List<Transform> enemySpawnPoints;
        [SerializeField] private Vector2 enemySpawnMinMax;

        public bool Initialized {get; private set;}

        public List<GameObject> TrySpawn()
        {
            if(Initialized)
                return null;

            int spawnAmount = Mathf.RoundToInt(UnityEngine.Random.Range(enemySpawnMinMax.x, enemySpawnMinMax.y));

            if(spawnAmount > enemySpawnPoints.Count)
                spawnAmount = enemySpawnPoints.Count;
            
            List<Transform> shuffledSpawnPoints = enemySpawnPoints;
            RandomValues.Shuffle(ref shuffledSpawnPoints);

            List<GameObject> enemies = new List<GameObject>();
            int enemyCycle = 0;
            for (int i = 0; i < spawnAmount; i++)
            {
                
                
                var enemyObj = Instantiate(enemyPrefab[enemyCycle], shuffledSpawnPoints[i].position, Quaternion.identity);
                enemyCycle += 1;
                enemyCycle %= enemyPrefab.Count;
                enemies.Add(enemyObj);
            }
            Initialized = true;
            return enemies;
        }

        public void NormalSpawn()
        {
            if(Initialized)
                return;

            int spawnAmount = Mathf.RoundToInt(UnityEngine.Random.Range(enemySpawnMinMax.x, enemySpawnMinMax.y));

            if(spawnAmount > enemySpawnPoints.Count)
                spawnAmount = enemySpawnPoints.Count;
            
            List<Transform> shuffledSpawnPoints = enemySpawnPoints;
            RandomValues.Shuffle(ref shuffledSpawnPoints);

            List<GameObject> enemies = new List<GameObject>();
            int enemyCycle = 0;
            for (int i = 0; i < spawnAmount; i++)
            {
                var enemyObj = Instantiate(enemyPrefab[enemyCycle], shuffledSpawnPoints[i].position, Quaternion.identity);
                enemyCycle += 1;
                enemyCycle %= enemyPrefab.Count;
                enemies.Add(enemyObj);
            }
            Initialized = true;
        }
    }
}
