using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering;

namespace KaitoMajima
{
    public class PostProcessWeightChanger : MonoBehaviour
    {
        [SerializeField] private Volume postProcessVolume;

        [InfoBox("Please ensure that the min and max value of the change value's tween are equal to 0 and 1 respectively.")]
        [SerializeField] private ChangeValue changeValueTween;

        private void Start()
        {
            changeValueTween.onValueChanged += ChangeWeight;
        }

        private void ChangeWeight(float weightValue)
        {
            postProcessVolume.weight = weightValue;
        }

        private void OnDestroy()
        {
            changeValueTween.onValueChanged -= ChangeWeight;
        }
    }
}
