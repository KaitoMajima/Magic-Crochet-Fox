using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class SpawnObject : MonoBehaviour
    {
        [SerializeField] private GameObject objectToSpawn;

        [SerializeField] private Transform spawnPoint;

        public void Spawn()
        {
            var instantiatedObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
        }

        public void ChangeObject(GameObject obj)
        {
            objectToSpawn = obj;
        }
    }
}
