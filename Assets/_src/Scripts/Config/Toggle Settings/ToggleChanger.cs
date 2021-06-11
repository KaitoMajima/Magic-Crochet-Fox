using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KaitoMajima
{
    public class ToggleChanger : MonoBehaviour
    {
        [SerializeField] private ToggleSetting settingToChange;
        [SerializeField] private Toggle toggle;

        private void Awake()
        {
            toggle.SetIsOnWithoutNotify(settingToChange.setting);
            toggle.onValueChanged.AddListener(Change);
        }
        public void Change(bool condition)
        {
            settingToChange.ChangeSetting(condition);
        }

        private void OnDestroy()
        {
            toggle.onValueChanged.RemoveListener(Change);
        }
    }
}
