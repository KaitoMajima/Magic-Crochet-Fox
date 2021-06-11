using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace KaitoMajima
{
    public class WebGLGameObjectEnabler : MonoBehaviour
    {
        [SerializeField] private GameObject objToEnable;
        [SerializeField] private bool shouldEnable;
        [SerializeField] private bool shouldEnableOnOtherPlatforms;
        [SerializeField] private bool shouldEnableOnEditor;

        void Start()
        {
            
            #if UNITY_EDITOR
                objToEnable.SetActive(shouldEnableOnEditor);
            #elif UNITY_WEBGL
                objToEnable.SetActive(shouldEnable);
            #else
                objToEnable.SetActive(shouldEnableOnOtherPlatforms);
            #endif

            
        }
        
    }
}
