using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

namespace KaitoMajima
{
    public class ImpulseLimiter : MonoBehaviour
    {
        [SerializeField] private ArrowListSetting arrowListSetting;
        [SerializeField] private CinemachineImpulseListener impulseListener;
        private const int IMPULSE_FULL = 0;
        private const int IMPULSE_PARTIAL = 1;
        private const int IMPULSE_OFF = 2;

        private void Start()
        {
            int impulseMode = arrowListSetting.setting;

            ChangeSetting(impulseMode);

            arrowListSetting.onSettingChanged += ChangeSetting;
        }

        private void ChangeSetting(int mode)
        {
            switch (mode)
            {
                case IMPULSE_FULL:
                    impulseListener.m_Gain = 1;
                    break;
                case IMPULSE_PARTIAL:
                    impulseListener.m_Gain = 0.5f;
                    break;
                case IMPULSE_OFF:
                    impulseListener.m_Gain = 0;
                    break;
            }
        }
    }
}
