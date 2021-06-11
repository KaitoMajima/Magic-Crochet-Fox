using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace KaitoMajima
{
    public class ChangeValue : TweenController
    {
        [SerializeField] private PlayOnEnableTween playOnEnable = PlayOnEnableTween.None;
        [SerializeField] private TweenSettings tweenSettings = TweenSettings.Default;
        [SerializeField] private TweenValueSettings tweenValueSettings;
        public float Value {get; private set;}

        public Action<float> onValueChanged;

        private Tween currentTween;
        private float originalValue;
        private void OnEnable()
        {
            if(playOnEnable == PlayOnEnableTween.Activate)
                Activate();
            if(playOnEnable == PlayOnEnableTween.Deactivate)
                Deactivate();
        }
        public override void Activate()
        {
            if(currentTween != null)
                if(currentTween.IsPlaying())
                    currentTween.Kill();

            if(tweenValueSettings.resetValues)
                Value = tweenValueSettings.startValue;
                
            if(!tweenSettings.useLoops)
            {
                currentTween = DOTween.To(() => Value, x => Value = x, tweenValueSettings.endValue, tweenSettings.duration)
                .SetEase(tweenSettings.easeType).OnUpdate(CallValueChanged);

            }
            else
            {
                currentTween = DOTween.To(() => Value, x => Value = x, tweenValueSettings.endValue, tweenSettings.duration)
                .SetEase(tweenSettings.easeType)
                .SetLoops(-1, tweenSettings.loopType)
                .OnUpdate(CallValueChanged);;
            }
            
        }

        public override void Deactivate()
        {
            if(currentTween != null)
                if(currentTween.IsPlaying())
                    currentTween.Kill();
            
            if(tweenValueSettings.resetValues)
                Value = tweenValueSettings.endValue;
            currentTween = DOTween.To(() => Value, x => Value = x, tweenValueSettings.startValue, tweenSettings.duration)
            .SetEase(tweenSettings.easeType)
            .OnUpdate(CallValueChanged);;
        }

        private void CallValueChanged()
        {
            onValueChanged?.Invoke(Value);
        }
    }
}
