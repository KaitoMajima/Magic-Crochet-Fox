using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

namespace KaitoMajima
{
    [Serializable]
    public struct TimeStopSettings
    {
        public float timeStopLength;

        public float timeStopDelay;
        [Range(0, 1)]
        public float timeStopScale;


        public static TimeStopSettings Default = new TimeStopSettings()
        {
            timeStopLength = 0.2f,
            timeStopDelay = 0.15f,
            timeStopScale = 0
        };
    }
    public class TimeStop : TweenController
    {
        [SerializeField] private TimeStopSettings timeStopSettings = TimeStopSettings.Default;

        [SerializeField] private Ease easeType = Ease.Linear;

        [SerializeField] private PlayOnEnableTween playOnEnable = PlayOnEnableTween.None;

        private Tween currentTween;

        private void OnEnable()
        {
            PauseController.onPauseTriggered += StopTween;

            if(playOnEnable == PlayOnEnableTween.Activate)
                Activate();
        }

        public override void Activate()
        {
            if(timeStopSettings.timeStopLength == 0)
                return;
            
            StartCoroutine(Delay(timeStopSettings.timeStopDelay, 
            () => 
            {
                currentTween = DOTween.Sequence().Append(DOTween.To(() => Time.timeScale, x => Time.timeScale = x, timeStopSettings.timeStopScale, 0))
                .Append(DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1, timeStopSettings.timeStopLength).SetEase(easeType).SetUpdate(true));
            }));
            
            
        }

        private void StopTween(bool pause)
        {
            if(!pause)
                return;
            
            if(currentTween == null)
                return;
            
            currentTween.Kill();
                
        }

        private IEnumerator Delay(float seconds, Action callback)
        {
            yield return new WaitForSeconds(seconds);
            callback?.Invoke();
        }
    }
}
