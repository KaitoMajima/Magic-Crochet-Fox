using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public struct DashState
    {
        public Action OnCooldownEnd;
        public float dashTime;
        public float cooldown;
    }

    [Serializable]
    public struct DashSettings
    {
        public MovementSettings movementSettings;
        public float duration;

        public float dampTime;
        
        public float cooldownTime;
        public static DashSettings Default = new DashSettings()
        {
            movementSettings = MovementSettings.Default,
            duration = 0.6f,
            dampTime = 0.2f,
            cooldownTime = 0.5f
        };
    }
    public static class Dash
    {
        public static void SetDash(ref DashState state, in DashSettings settings)
        {
            state.dashTime = settings.duration;
            state.cooldown = settings.cooldownTime;
        }
    }
}
