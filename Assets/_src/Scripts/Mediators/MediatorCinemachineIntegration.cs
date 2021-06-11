using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace KaitoMajima
{
    public class MediatorCinemachineIntegration : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private TransformReference initialTransformReference;

        [SerializeField] private bool assignMediatorOnStart = true;

        private void Start()
        {
            if(assignMediatorOnStart)
                AssignMediator(initialTransformReference);
        }

        private void AssignMediator(TransformReference transformReference)
        {
            virtualCamera.Follow = transformReference.Value;
        }
    }
}
