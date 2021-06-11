using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KaitoMajima
{
    public class UIFade : TweenController
    {
        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField]
        private PlayOnEnableTween playOnEnable = PlayOnEnableTween.None;

        [SerializeField]
        private bool destroyOnEndDeactivate;

        [SerializeField]
        private bool resetFade;

        [SerializeField]
        private TweenSettings tweenSettings = TweenSettings.Default;

        private void OnEnable()
        {
            if(playOnEnable == PlayOnEnableTween.Activate)
                Activate();
            if(playOnEnable == PlayOnEnableTween.Deactivate)
                Deactivate();
        }
        public override void Activate()
        {
            if(resetFade)
                canvasGroup.alpha = 0;
            
            Tween tween = canvasGroup.DOFade(1, tweenSettings.duration).SetEase(tweenSettings.easeType);
            if(tweenSettings.ignoreTimeScale)
                tween.SetUpdate(true);
        }

        public override void Deactivate()
        {
            if(resetFade)
                canvasGroup.alpha = 1;
            
            Tween tween = canvasGroup.DOFade(0, tweenSettings.duration).SetEase(tweenSettings.easeType).OnComplete(DestroyOnEnd);
            if(tweenSettings.ignoreTimeScale)
                tween.SetUpdate(true);
        }

        private void DestroyOnEnd()
        {
            if(destroyOnEndDeactivate)
                Destroy(gameObject);
        }
    }
}
