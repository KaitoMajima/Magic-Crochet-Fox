using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    [CreateAssetMenu(fileName = "New Value Setting", menuName = "Scriptable Objects/Value Setting")]
    public class ValueSetting : ScriptableObject
    {
        public float setting;
        public Action<float> onSettingChanged;
        public virtual void ChangeSetting(float value) 
        {
            setting = value;
            onSettingChanged?.Invoke(value);
        }   
    }
}
