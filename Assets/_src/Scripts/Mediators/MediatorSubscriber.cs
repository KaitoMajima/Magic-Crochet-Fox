using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class MediatorSubscriber : MonoBehaviour
    {
        [SerializeField] private TransformReference transformReference;
        [SerializeField] private Transform initialTransformToSubscribe;

        [SerializeField] private bool subscribeAtAwake = true;

        private void Awake()
        {
            if (subscribeAtAwake)
                Subscribe(initialTransformToSubscribe);
        }
        private void Subscribe(Transform transformToSubscribe)
        {
            transformReference.Value = transformToSubscribe;
        }
    }
}
