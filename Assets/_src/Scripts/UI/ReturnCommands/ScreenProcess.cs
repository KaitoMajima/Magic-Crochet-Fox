using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class ScreenProcess : MonoBehaviour
    {
        [SerializeField] private ReturnerProcessor returnerProcessor;
        [SerializeField] private ReturnScreen returnScreen;

        private void OnEnable()
        {
            returnerProcessor?.Subscribe(returnScreen);
        }
    }
}
