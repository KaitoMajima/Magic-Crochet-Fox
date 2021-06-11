using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KaitoMajima
{
    public class SliderButton : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private float step;

        public void Step()
        {
            slider.value += step;
            slider.value = Mathf.Clamp(slider.value, slider.minValue, slider.maxValue);
        }
    }
}
