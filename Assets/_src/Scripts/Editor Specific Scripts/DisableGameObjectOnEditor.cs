using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace KaitoMajima
{
    public class DisableGameObjectOnEditor : MonoBehaviour
    {
        [SerializeField] private GameObject gameObjectToDisable;
        [SerializeField] private bool shouldBeQueuedForEnabling;

        private void Start()
        {
            gameObjectToDisable.SetActive(shouldBeQueuedForEnabling);
        }
    }
}
