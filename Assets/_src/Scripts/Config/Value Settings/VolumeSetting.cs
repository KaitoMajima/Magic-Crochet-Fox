using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    [CreateAssetMenu(fileName = "New Volume Setting", menuName = "Scriptable Objects/Volume Setting")]
    public class VolumeSetting : ScriptableObject
    {
        public VolumeType setting;
        public Action<VolumeType> onSettingChanged;
        public virtual void ChangeSetting(float volume) 
        {
            setting.volumeValue = volume;
            onSettingChanged?.Invoke(setting);
        }   
    }

    [Serializable]
    public class VolumeType 
    {
        public string volumeName;
        public float volumeValue;

        public VolumeType(string name, float value)
        {
            volumeName = name;
            volumeValue = value;
        }
    }
}
