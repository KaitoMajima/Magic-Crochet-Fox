using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Sirenix.OdinInspector;

namespace KaitoMajima
{
    [RequireComponent(typeof(Light2D))]
    public class ApplyPaletteTo2DLight : MonoBehaviour
    {
        [SerializeField] private Light2D rend;
        [ColorPalette]
        [SerializeField] private Color color;

        [Button("Catch This Object Light")]
        public void CatchThisObjectLight()
        {
            rend = GetComponent<Light2D>();
        }

        [Button("Apply Color To Light")]
        public void ApplyColor()
        {
            rend.color = color;
        }
    }
}
