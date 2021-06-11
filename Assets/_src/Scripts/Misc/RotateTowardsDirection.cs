using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class RotateTowardsDirection : MonoBehaviour
    {
        [SerializeField] private Transform rotatedTransform;

        public void Rotate(Vector2 direction)
        {
            rotatedTransform.localRotation = Quaternion.FromToRotation(Vector2.right, direction);
        }
    }
}
