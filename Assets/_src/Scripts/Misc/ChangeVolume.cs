using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace KaitoMajima
{
    public class ChangeVolume : MonoBehaviour
    {
        [SerializeField] private ValueSetting volumeSetting;

        [SerializeField] private ValueSetting sfxSetting;

        [SerializeField] private ValueSetting musicSetting;

        [SerializeField] private AudioMixer mainMixer;

        private void Start()
        {
            //todo...
        }
    }
}
