using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KaitoMajima
{
    public class SliderValueToText : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TextMeshProUGUI textComponent;
        void Start()
        {
            slider.onValueChanged.AddListener(ChangeTextValue);
        }

        private void ChangeTextValue(float value)
        {
            textComponent.text = value.ToString();
        }

        private void OnDestroy()
        {
            slider.onValueChanged.RemoveListener(ChangeTextValue);
            
        }
    }
}
