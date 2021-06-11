using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class SendObject : MonoBehaviour
    {
        [SerializeField]
        private Transform objectTransform;

        [SerializeField]
        private bool objectStickOnTransform;

        [SerializeField]
        private GameObject objectPrefab;

        public void SpawnObject()
        {
            GameObject behaviourObject;

            if(objectStickOnTransform)
                behaviourObject = Instantiate(objectPrefab, objectTransform.position, Quaternion.identity, objectTransform);
            else
                behaviourObject = Instantiate(objectPrefab, objectTransform.position, Quaternion.identity);
        }

    }
}
