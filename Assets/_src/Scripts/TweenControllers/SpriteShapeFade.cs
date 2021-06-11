using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.U2D;

namespace KaitoMajima
{
    public class SpriteShapeFade : TweenController
    {
        [SerializeField]
        private SpriteShapeRenderer spriteRenderer;

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
            var currentAlpha = spriteRenderer.color.a;
            DOTween.To(() => currentAlpha, x => currentAlpha = x, 1, tweenSettings.duration).SetEase(tweenSettings.easeType).OnUpdate(() => 
            spriteRenderer.color = ChangeAlpha(spriteRenderer.color, currentAlpha));
            
        }

        public override void Deactivate()
        {
            var currentAlpha = spriteRenderer.color.a;
            DOTween.To(() => currentAlpha, x => currentAlpha = x, 0, tweenSettings.duration).SetEase(tweenSettings.easeType).OnUpdate(() => 
            spriteRenderer.color = ChangeAlpha(spriteRenderer.color, currentAlpha)).OnComplete(DestroyOnEnd);
        }
        private Color ChangeAlpha(Color color, float alpha)
        {
            var currentColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
            return currentColor;
        }

        private void DestroyOnEnd()
        {
            if(destroyOnEndDeactivate)
                Destroy(gameObject);
        }
    }
}
