using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KaitoMajima
{
    public class VolumeChanger : MonoBehaviour
    {
        [SerializeField] private VolumeSetting settingToChange;
        [SerializeField] private Slider slider;

        [SerializeField] private TextMeshProUGUI valueTextComponent;

        private void Awake()
        {
            slider.SetValueWithoutNotify(settingToChange.setting.volumeValue);
            if(valueTextComponent != null) valueTextComponent.text = settingToChange.setting.volumeValue.ToString();

            slider.onValueChanged.AddListener(Change);
        }
        public void Change(float value)
        {
            settingToChange.ChangeSetting(value);
        }

        private void OnDestroy()
        {
            slider.onValueChanged.RemoveListener(Change);
        }
    }
}
