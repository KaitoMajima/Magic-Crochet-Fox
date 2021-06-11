using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    [CreateAssetMenu(fileName = "New Arrow List Setting", menuName = "Scriptable Objects/Arrow List Setting")]
    public class ArrowListSetting : ScriptableObject
    {
        public int setting;

        public Action<int> onSettingChanged;
        public virtual void ChangeSetting(int index) 
        {
            setting = index;
            onSettingChanged?.Invoke(setting);
        }   
    }
}
