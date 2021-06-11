using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace KaitoMajima
{
    public class LightCull : MonoBehaviour
    {
        [SerializeField] private Light2D light2D;
        [SerializeField] private GameObject objToDisable;
        private Camera mainCamera;
        public enum CullType
        {
            Visibility,
            LightBounds
        }

        [SerializeField] private CullType cullType;

        private void Start()
        {
            mainCamera = Camera.main;
        }
        private void Update()
        {
            if(cullType != CullType.LightBounds)
                return;
            
            float lightRadius = light2D.pointLightOuterRadius;

            var lightTransform = light2D.transform;

            Vector2 lightRadiusMinBounds = mainCamera.WorldToViewportPoint(new Vector2(lightTransform.position.x - lightRadius, 
            lightTransform.position.y - lightRadius));

            Vector2 lightRadiusMaxBounds = mainCamera.WorldToViewportPoint(new Vector2(lightTransform.position.x + lightRadius, 
            lightTransform.position.y + lightRadius));

            bool insideCameraBounds = lightRadiusMaxBounds.x >= 0 && lightRadiusMinBounds.x <= 1 
            && lightRadiusMaxBounds.y >= 0 && lightRadiusMinBounds.y <= 1;

            if(insideCameraBounds)
            {
                if(!objToDisable.activeSelf)
                {
                    objToDisable.SetActive(true);
                }
                    
            }
            else
            {
                if(objToDisable.activeSelf)
                {
                    objToDisable.SetActive(false);
                }
            }
        }
        private void OnBecameVisible()
        {
            if(cullType == CullType.Visibility)
                objToDisable.SetActive(true);  
        }

        private void OnBecameInvisible()
        {
            if(cullType == CullType.Visibility)
                objToDisable.SetActive(false);
        }


    }
}
