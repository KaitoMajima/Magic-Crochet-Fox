using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KaitoMajima
{
    public class ColorChanger : TweenController
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private bool useMaterial = true;
        [SerializeField] private string property;

        [SerializeField] private Gradient gradient;
        [SerializeField] private PlayOnEnableTween playOnEnable = PlayOnEnableTween.Activate;

        [SerializeField] private TweenSettings tweenSettings = TweenSettings.Default;

        private Material rendererMaterial;
        private void Awake()
        {
            rendererMaterial = spriteRenderer.material;
        }

        private void OnEnable()
        {
            if(playOnEnable == PlayOnEnableTween.Activate)
                Activate();
            if(playOnEnable == PlayOnEnableTween.Deactivate)
                Deactivate();
        }
        public override void Activate()
        {
            if(useMaterial)
            {
                DOTween.Sequence().Append(rendererMaterial.DOColor(gradient.Evaluate(0), property, 0))
                .Append(rendererMaterial.DOColor(gradient.Evaluate(1), property, tweenSettings.duration).SetEase(tweenSettings.easeType));
                
            }
            else
            {
                spriteRenderer.color = gradient.Evaluate(0);
                spriteRenderer.DOKill();
                spriteRenderer.DOGradientColor(gradient, tweenSettings.duration).SetEase(tweenSettings.easeType);

            }
            
        }

        public override void Deactivate()
        {
            if(useMaterial)
            {
                DOTween.Sequence().Append(rendererMaterial.DOColor(gradient.Evaluate(1), property, 0))
                .Append(rendererMaterial.DOColor(gradient.Evaluate(0), property, tweenSettings.duration).SetEase(tweenSettings.easeType));
            }
            
        }
    }
}
