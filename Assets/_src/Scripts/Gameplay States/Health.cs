using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace KaitoMajima
{
    [Serializable]
    public struct HealthState
    {
        
        public int Health;
        public int MaxHealth;
        public static HealthState Default = new HealthState()
        {
            Health = 100,
            MaxHealth = 100
        };
    }
    public static class Health
    {
        public static void Heal(ref HealthState state, int amount)
        {
            state.Health += amount;
            
            if(state.Health > state.MaxHealth)
                state.Health = state.MaxHealth;
        }

        public static void Damage(ref HealthState state, int amount)
        {
            state.Health -= amount;
            
            if(state.Health < 0)
                state.Health = 0;
            
        }
    }

}
