using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace KaitoMajima
{
    public struct AfterImageState
    {
        public float afterImagesRemaining;
        public float singleAfterImageTimer;
        public float overallAfterImageTimer;
    }
    [Serializable]
    public struct AfterImageSettings
    {
        public enum AfterImageMode
        {
            ByCount,
            ByFixedTime
        }

        public AfterImageMode afterImageMode;
        public int afterImageCount;

        public float afterImageInterval;

        public float overallAfterImageTime;

        public static AfterImageSettings Default = new AfterImageSettings()
        {
            afterImageMode = AfterImageSettings.AfterImageMode.ByCount,
            afterImageCount = 2,
            afterImageInterval = 0.2f,
            overallAfterImageTime = 0.6f
        };
    }
    public static class AfterImage
    {
        public static void InitiateAfterImages(ref AfterImageState state, in AfterImageSettings settings)
        {
            state.afterImagesRemaining = settings.afterImageCount;
            state.singleAfterImageTimer = settings.afterImageInterval;

            if(settings.afterImageMode == AfterImageSettings.AfterImageMode.ByCount)
                state.overallAfterImageTimer = settings.afterImageInterval * settings.afterImageCount;
            else if(settings.afterImageMode == AfterImageSettings.AfterImageMode.ByFixedTime)
                state.overallAfterImageTimer = settings.overallAfterImageTime;

            
        }
        public static void InstantiateAfterImage(ref AfterImageState state, in AfterImageSettings settings)
        {
            state.afterImagesRemaining--;
            state.singleAfterImageTimer = settings.afterImageInterval;
        }
    }
}
