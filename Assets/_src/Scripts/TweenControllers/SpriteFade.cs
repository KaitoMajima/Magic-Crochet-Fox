using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KaitoMajima
{
    public class SpriteFade : TweenController
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private PlayOnEnableTween playOnEnable = PlayOnEnableTween.None;

        [SerializeField]
        private bool destroyOnEndDeactivate;

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
            spriteRenderer.DOFade(1, tweenSettings.duration).SetEase(tweenSettings.easeType);
        }

        public override void Deactivate()
        {
            spriteRenderer.DOFade(0, tweenSettings.duration).SetEase(tweenSettings.easeType).OnComplete(DestroyOnEnd);
        }

        private void DestroyOnEnd()
        {
            if(destroyOnEndDeactivate)
                Destroy(gameObject);
        }
    }
}
