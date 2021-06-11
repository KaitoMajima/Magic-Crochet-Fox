using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class ArrowListSettingAssigner : MonoBehaviour
    {
        [SerializeField] protected ArrowListSetting arrowListSetting;

        private void Start()
        {
            SettingChange(arrowListSetting.setting);

            arrowListSetting.onSettingChanged += SettingChange;
        }

        protected virtual void SettingChange(int index)
        {

        }

        private void OnDestroy()
        {
            arrowListSetting.onSettingChanged -= SettingChange;
        }
    }
}