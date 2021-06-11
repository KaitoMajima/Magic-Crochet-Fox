using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class ArrowListChanger : MonoBehaviour
    {
        [SerializeField] private ArrowListSetting settingToChange;
        [SerializeField] private ArrowDropdown arrowDropdown;


        private void Awake()
        {
            arrowDropdown.SetOptionWithoutNotify(settingToChange.setting);
            arrowDropdown.onValueChanged.AddListener(Change);
        }
        public void Change(int index)
        {
            settingToChange.ChangeSetting(index);
        }

        private void OnDestroy()
        {
            arrowDropdown.onValueChanged.RemoveListener(Change);
        }
    }
}
