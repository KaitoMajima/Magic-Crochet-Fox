using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class RotateTowardsObject : MonoBehaviour
    {
        [SerializeField] private Transform rotatedTransform;

        [SerializeField] private Transform targetTransform;

        private void Awake()
        {
            if(targetTransform == null)
                targetTransform = FindObjectOfType<FollowReticle>().transform;
        }
        private void Update()
        {
            Vector2 offset = targetTransform.position - rotatedTransform.position;

            rotatedTransform.localRotation = Quaternion.FromToRotation(Vector2.right, offset);
        }
    }
}
