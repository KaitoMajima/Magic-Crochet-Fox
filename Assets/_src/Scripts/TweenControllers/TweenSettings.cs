using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace KaitoMajima
{
    [Serializable]
    public struct TweenSettings
    {
        public float duration;
        public Ease easeType;
        public bool useLoops;

        public bool ignoreTimeScale;
        public LoopType loopType;

        public static TweenSettings Default = new TweenSettings()
        {
            duration = 1,
            easeType = Ease.Linear,
        };
    }
    [Serializable]
    public struct TweenValueSettings
    {
        public bool resetValues;
        public float startValue;
        public float endValue;

        public static TweenValueSettings Default = new TweenValueSettings()
        {
            startValue = 1,
            endValue = 1
        };
    }

    [Serializable]
    public struct TweenVector2Settings
    {
        public bool resetValues;
        public Vector2 startValue;
        public Vector2 endValue;

        public static TweenVector2Settings Default = new TweenVector2Settings()
        {
            startValue = Vector2.one,
            endValue = Vector2.one
        };
    }

    [Serializable]
    public struct TweenVector3Settings
    {
        public bool resetValues;
        public Vector3 startValue;
        public Vector3 endValue;

        public static TweenVector3Settings Default = new TweenVector3Settings()
        {
            startValue = Vector3.one,
            endValue = Vector3.one
        };
    }


    [Serializable]
    public struct TweenScaleValueSettings
    {
        public enum ScaleType 
        {
            RateScale,
            FixedVectorScale
        }

        public bool resetValues;
        public ScaleType scaleType;
        public float rateScale;
        public Vector2 fixedScale;

        public static TweenScaleValueSettings Default = new TweenScaleValueSettings()
        {
            scaleType = ScaleType.RateScale,
            rateScale = 2,
            fixedScale = Vector2.one
        };
    }
}
