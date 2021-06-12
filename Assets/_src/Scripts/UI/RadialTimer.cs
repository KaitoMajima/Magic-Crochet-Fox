using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KaitoMajima
{
    public class RadialTimer : MonoBehaviour
    {
        [SerializeField] private ChangeValue valueChanger;
        [SerializeField] private Image image;

        private void Start()
        {
            valueChanger.onValueChanged += ChangeTimer;
        }

        private void ChangeTimer(float value)
        {
            image.fillAmount = value;
        }
    }
}
