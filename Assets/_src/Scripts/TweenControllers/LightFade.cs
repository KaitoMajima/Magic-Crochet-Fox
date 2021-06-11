using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

namespace KaitoMajima
{
    public class LightFade : TweenController
    {
        [SerializeField] 
        private Light2D light2D;

        [SerializeField]
        private PlayOnEnableTween playOnEnable = PlayOnEnableTween.Deactivate;

        [SerializeField]
        private TweenSettings tweenSettings = TweenSettings.Default;

        [SerializeField]
        private bool destroyOnEndDeactivate;
        private void OnEnable()
        {
            if(playOnEnable == PlayOnEnableTween.Activate)
                Activate();
            if(playOnEnable == PlayOnEnableTween.Deactivate)
                Deactivate();
        }

        public override void Activate()
        {
            DOTween.To(() => light2D.intensity, x => light2D.intensity = x, 1, tweenSettings.duration).SetEase(tweenSettings.easeType);
        }
        
        public override void Deactivate()
        {
            DOTween.To(() => light2D.intensity, x => light2D.intensity = x, 0, tweenSettings.duration).SetEase(tweenSettings.easeType).OnComplete(() => DestroyOnEnd());
        }
    
        private void DestroyOnEnd()
        {
            if(!destroyOnEndDeactivate)
                return;
            Destroy(gameObject);
        }
    }
    
}
