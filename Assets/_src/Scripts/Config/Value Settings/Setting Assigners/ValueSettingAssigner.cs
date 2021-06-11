using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class ValueSettingAssigner : MonoBehaviour
    {
        [SerializeField] protected ValueSetting valueSetting;


        private void Start()
        {
            SettingChange(valueSetting.setting);

            valueSetting.onSettingChanged += SettingChange;
        }

        protected virtual void SettingChange(float value)
        {

        }

        private void OnDestroy()
        {
            valueSetting.onSettingChanged -= SettingChange;
        }
    }
}