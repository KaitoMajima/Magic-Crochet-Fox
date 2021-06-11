using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    [Serializable]
    public struct InvincibilityState
    {
        public bool isInvincible;
        public float invincibleTime;
        public bool isFlicking;

        public float flickingTime;
    }
    [Serializable]
    public struct InvincibilitySettings
    {
        public float invincibleMaxTime;

        public float flickMaxTime;
        public static InvincibilitySettings Default = new InvincibilitySettings()
        {
            invincibleMaxTime = 0.6f,
            flickMaxTime = 0.2f
        };
    }
    public static class Invincibility
    {
        public static void SetInvincibility(ref InvincibilityState state, in InvincibilitySettings settings, in bool flicks)
        {
            state.invincibleTime = settings.invincibleMaxTime;
            state.isInvincible = true;

            if(flicks)
                state.flickingTime = settings.flickMaxTime;
        }

        public static void SetInvincibility(ref InvincibilityState state, in float duration)
        {

            state.invincibleTime = duration;
            state.isInvincible = true;

        }
        public static void SetFrames(ref InvincibilityState state)
        {
            if(state.invincibleTime <= 0)
                return;

            state.invincibleTime -= Time.deltaTime;

            if(state.invincibleTime <= 0)
                state.isInvincible = false;
        }

        public static void SetVisuals(ref InvincibilityState state, in InvincibilitySettings settings)
        {
            if(state.flickingTime <= 0)
                return;
            state.flickingTime -= Time.deltaTime;

            if(state.invincibleTime <= Time.deltaTime)
            {
                state.isFlicking = false;
                state.flickingTime = 0;
                return;
            }

            if(state.flickingTime > 0)
                return;
            
            state.isFlicking = !state.isFlicking;
            state.flickingTime = settings.flickMaxTime;

        }
    }
}
