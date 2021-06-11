using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class ToggleSettingAssigner : MonoBehaviour
    {
        [SerializeField] protected ToggleSetting toggleSetting;


        protected void Start()
        {
            SettingChange(toggleSetting.setting);

            toggleSetting.onSettingChanged += SettingChange;
        }

        protected virtual void SettingChange(bool condition)
        {

        }

        private void OnDestroy()
        {
            toggleSetting.onSettingChanged -= SettingChange;
        }
    }
}
