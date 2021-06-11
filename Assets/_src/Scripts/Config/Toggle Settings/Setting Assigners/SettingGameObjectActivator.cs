using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class SettingGameObjectActivator : ToggleSettingAssigner
    {
        [SerializeField] private GameObject[] objectsToActivate;

        protected override void SettingChange(bool condition)
        {
            
            foreach (var obj in objectsToActivate)
            {
                obj.SetActive(condition);
            }
        }
    }
}
