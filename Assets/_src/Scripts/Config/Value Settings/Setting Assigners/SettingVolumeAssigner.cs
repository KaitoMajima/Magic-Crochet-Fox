using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace KaitoMajima
{
    public class SettingVolumeAssigner : MonoBehaviour
    {
        [SerializeField] protected VolumeSetting volumeSetting;
        [SerializeField] protected AudioMixer mixer;

        private void Start()
        {
            SettingChange(volumeSetting.setting);

            volumeSetting.onSettingChanged += SettingChange;
        }
        
        protected virtual void SettingChange(VolumeType volume)
        {
            if(volume.volumeValue == 0)
            {
                mixer.SetFloat(volume.volumeName, -80);
                return;
            }
            float convertedVolume = RangeConverter.ConvertValues(volume.volumeValue, 0, 10, -40, 0);


            mixer.SetFloat(volume.volumeName, convertedVolume);
        }

        private void OnDestroy()
        {
            volumeSetting.onSettingChanged -= SettingChange;
        }
    }
    
}
