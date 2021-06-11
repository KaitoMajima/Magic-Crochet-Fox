using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace KaitoMajima
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ApplyPaletteToRenderer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer rend;
        [ColorPalette]
        [SerializeField] private Color color;

        [Button("Catch This Object Renderer")]
        public void CatchThisObjectRenderer()
        {
            rend = GetComponent<SpriteRenderer>();
        }

        [Button("Apply Color To Renderer")]
        public void ApplyColor()
        {
            rend.color = color;
        }
    }
}
