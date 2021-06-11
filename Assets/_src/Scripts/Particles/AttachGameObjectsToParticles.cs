using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace KaitoMajima
{
        
    [RequireComponent(typeof(ParticleSystem))]
    public class AttachGameObjectsToParticles : MonoBehaviour
    {
        public GameObject prefab;

        private ParticleSystem theParticleSystem;
        private List<GameObject> instances = new List<GameObject>();
        private ParticleSystem.Particle[] particles;

        [SerializeField] private bool sizeAffectsRange = true;
        [SerializeField] private bool alphaAffectsIntensity = true;
        [SerializeField] private bool endIfNotAlive = true;
        [ShowIf("sizeAffectsRange")]
        [SerializeField] private float sizeMultiplier = 1;
        [ShowIf("alphaAffectsIntensity")]
        [SerializeField] private float alphaMultiplier = 1;

        private void Awake()
        {
        //     if (ParticleLightingSetting.ParticleLighting == 1)
        //     {
        //         Destroy(this);
        //     }
        }
        void Start()
        {
            theParticleSystem = GetComponent<ParticleSystem>();
            particles = new ParticleSystem.Particle[theParticleSystem.main.maxParticles];
        }

        void LateUpdate()
        {
            if (prefab == null) return;

            if (endIfNotAlive && !theParticleSystem.IsAlive()) Destroy(gameObject);

            int count = theParticleSystem.GetParticles(particles);

            while (instances.Count < count)
                instances.Add(Instantiate(prefab, theParticleSystem.transform));

            bool worldSpace = (theParticleSystem.main.simulationSpace == ParticleSystemSimulationSpace.World);
            for (int i = 0; i < instances.Count; i++)
            {
                if (i < count)
                {
                    Light2D light = instances[i].GetComponent<Light2D>();
                    if (sizeAffectsRange)
                    {
                        light.pointLightOuterRadius = particles[i].GetCurrentSize(theParticleSystem) * sizeMultiplier;
                    }
                    if (alphaAffectsIntensity)
                    {
                        float particleAlpha = particles[i].GetCurrentColor(theParticleSystem).a;
                        float normalizedLightValue = Mathf.InverseLerp(0, particles[i].startColor.a, particleAlpha);
                        float resultLightValue = Mathf.Lerp(0, 1, normalizedLightValue);
                        light.intensity = resultLightValue * alphaMultiplier;
                    }
                    
                    
                    if (worldSpace)
                        instances[i].transform.position = particles[i].position;
                    else
                        instances[i].transform.localPosition = particles[i].position;
                    instances[i].SetActive(true);
                }
                else
                {
                    instances[i].SetActive(false);
                }
            }
        }
    }

}