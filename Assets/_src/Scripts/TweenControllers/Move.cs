using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KaitoMajima
{
    public class Move : TweenController
    {
        [SerializeField] private Transform movingTransform;

        [SerializeField] private PlayOnEnableTween playOnEnable = PlayOnEnableTween.None;

        [SerializeField] private TweenSettings tweenSettings = TweenSettings.Default;

        [SerializeField] private TweenVector2Settings tweenVectorSettings = TweenVector2Settings.Default;

        private void OnEnable()
        {
            if(playOnEnable == PlayOnEnableTween.Activate)
                Activate();
            if(playOnEnable == PlayOnEnableTween.Deactivate)
                Deactivate();
        }
        public override void Activate()
        {   
            movingTransform.localPosition = tweenVectorSettings.startValue;
            Tween tween;
            if(!tweenSettings.useLoops)
                tween = movingTransform.DOLocalMove(tweenVectorSettings.endValue, tweenSettings.duration).SetEase(tweenSettings.easeType);
            else
                tween = movingTransform.DOLocalMove(tweenVectorSettings.endValue, tweenSettings.duration).SetEase(tweenSettings.easeType).SetLoops(-1, tweenSettings.loopType);
            
            if(tweenSettings.ignoreTimeScale)
                tween.SetUpdate(true);
        }

        public override void Deactivate()
        {
            movingTransform.localPosition = tweenVectorSettings.endValue;
            Tween tween;

            tween = movingTransform.DOLocalMove(tweenVectorSettings.startValue, tweenSettings.duration).SetEase(tweenSettings.easeType);

            if(tweenSettings.ignoreTimeScale)
                tween.SetUpdate(true);
        }
    }
}
