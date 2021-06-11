using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    
    [CreateAssetMenu(fileName = "New Toggle Setting", menuName = "Scriptable Objects/Toggle Setting")]
    public class ToggleSetting : ScriptableObject
    {
        public bool setting;

        public Action<bool> onSettingChanged; 
        public virtual void ChangeSetting(bool condition) 
        {
            setting = condition;
            onSettingChanged?.Invoke(setting);
        }   
    }

    
}
