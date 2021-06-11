using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem.LowLevel;

namespace KaitoMajima
{
    
    public class ParticleLimiter : MonoBehaviour
    {
        [Required][SerializeField] private ParticleSystem mainParticleSystem;

        [SerializeField] private ArrowListSetting particleSetting;
        private ParticleSystem.EmissionModule emissionModule;
        [Range(0, 1)][SerializeField] private float limiterRate = 0.5f;
        [SerializeField] private bool limitBursts = false;
        [ShowIf("limitBursts")]
        [Range(0, 1)] [SerializeField] private float burstLimiterRate = 0.5f;
        private ParticleSystem.MinMaxCurve originalRateOverTime;
        private ParticleSystem.MinMaxCurve originalRateOverDistance;
        private int limitValue = 0;

        private const int PARTICLE_FULL = 0;
        private const int PARTICLE_PARTIAL = 1;
        private void Awake()
        {
            originalRateOverTime = mainParticleSystem.emission.rateOverTime;
            originalRateOverDistance = mainParticleSystem.emission.rateOverDistance;
            emissionModule = mainParticleSystem.emission;

            limitValue = particleSetting.setting;
            LimitRates();
            LimitBursts();
            particleSetting.onSettingChanged += ChangeSetting;
        }

        private void ChangeSetting(int setting)
        {
            limitValue = setting;

            LimitRates();
            LimitBursts();
        }

        private void LimitRates()
        {
            switch (limitValue)
            {
                case PARTICLE_FULL:
                    emissionModule.rateOverTime = originalRateOverTime;
                    emissionModule.rateOverDistance = originalRateOverDistance;
                    break;
                case PARTICLE_PARTIAL:
                    emissionModule.rateOverTime = new ParticleSystem.MinMaxCurve(
                        originalRateOverTime.constantMax * limiterRate);
                    emissionModule.rateOverDistance = new ParticleSystem.MinMaxCurve(
                        originalRateOverDistance.constantMax * limiterRate);
                    break;

            }
        }

        private void LimitBursts()
        {
            if (limitValue == PARTICLE_PARTIAL && limitBursts)
            {
                ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[emissionModule.burstCount];
                emissionModule.GetBursts(bursts);

                for (int i = 0; i < bursts.Length; i++)
                {
                    bursts[i].count = new ParticleSystem.MinMaxCurve(
                bursts[i].count.constantMax * burstLimiterRate);
                }
                emissionModule.SetBursts(bursts);
            }
        }
        private void OnDestroy()
        {
            particleSetting.onSettingChanged -= ChangeSetting;
        }
    }

}