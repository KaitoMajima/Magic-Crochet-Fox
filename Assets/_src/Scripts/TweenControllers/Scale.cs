using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace KaitoMajima
{
    public class Scale : TweenController
    {
        [SerializeField] 
        private Transform scaledTransform;

        [SerializeField]
        private PlayOnEnableTween playOnEnable = PlayOnEnableTween.None;

        [SerializeField]
        private TweenSettings tweenSettings = TweenSettings.Default;

        [SerializeField]
        private TweenScaleValueSettings tweenScaleValueSettings = TweenScaleValueSettings.Default;

        private Vector3 originalScale;
        
        private void Start()
        {
            originalScale = scaledTransform.localScale;
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

            if(!tweenSettings.useLoops)
            {
                if(tweenScaleValueSettings.resetValues)
                    scaledTransform.localScale = originalScale;
                    
                if(tweenScaleValueSettings.scaleType == TweenScaleValueSettings.ScaleType.FixedVectorScale)
                    scaledTransform.DOScale(tweenScaleValueSettings.fixedScale, tweenSettings.duration).SetEase(tweenSettings.easeType);
                else
                    scaledTransform.DOScale(tweenScaleValueSettings.rateScale, tweenSettings.duration).SetEase(tweenSettings.easeType);
                
                
            }
            else
            {
                if(tweenScaleValueSettings.scaleType == TweenScaleValueSettings.ScaleType.FixedVectorScale)
                    scaledTransform.DOScale(tweenScaleValueSettings.fixedScale, tweenSettings.duration).SetEase(tweenSettings.easeType).SetLoops(-1, tweenSettings.loopType);
                else
                    scaledTransform.DOScale(tweenScaleValueSettings.rateScale, tweenSettings.duration).SetEase(tweenSettings.easeType).SetLoops(-1, tweenSettings.loopType);
            }
            
        }

        public override void Deactivate()
        {
            scaledTransform.DOKill();
            scaledTransform.DOScale(originalScale, tweenSettings.duration).SetEase(tweenSettings.easeType);
        }

    }
}
