using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace KaitoMajima
{
    public static class Movement
    {

        public static void Move(ref MovementState state, in MovementSettings settings, in MovementInput input, float deltaTime)
        {
            Accelerate(ref state.Velocity, input.MoveVector, settings.AccelerationRate,  settings.MaxSpeed, deltaTime);
            Decelerate(ref state.Velocity, input.MoveVector, settings.DecelerationRate, deltaTime);
        }
        
        public static void Move(ref MovementState state, in MovementSettings settings, in Vector2 input, float deltaTime)
        {
            Accelerate(ref state.Velocity, input, settings.AccelerationRate,  settings.MaxSpeed, deltaTime);
            Decelerate(ref state.Velocity, input, settings.DecelerationRate, deltaTime);
        }

        public static void MoveHorizontally(ref MovementState state, in MovementSettings settings, in MovementInput input, float deltaTime)
        {
            Accelerate(ref state.Velocity.x, input.MoveVector.x, settings.AccelerationRate, settings.MaxSpeed, deltaTime);
            Decelerate(ref state.Velocity.x, input.MoveVector.x, settings.DecelerationRate, deltaTime);
        }
        

        private static void Accelerate(ref Vector2 velocity, in Vector2 input, float acceleration,  float maxSpeed, float deltaTime)
        {
            if(Mathf.Abs(input.x) > 0)
            {
                velocity.x += input.x * (acceleration * deltaTime);
                velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed); 
            }
            if(Mathf.Abs(input.y) > 0)
            {
                velocity.y += input.y * (acceleration * deltaTime);
                velocity.y = Mathf.Clamp(velocity.y, -maxSpeed, maxSpeed);
            }
        }

        private static void Accelerate(ref float velocity, in float input, float acceleration,  float maxSpeed, float deltaTime)
        {
            if(Mathf.Abs(input) > 0)
            {
                velocity += input * (acceleration * deltaTime);
                velocity = Mathf.Clamp(velocity, -maxSpeed, maxSpeed); 
            }

        }

        public static void Pulse(ref MovementState state, in MovementSettings settings, in Vector2 input)
        {
            if(Mathf.Abs(input.x) > 0)
                state.Velocity.x += input.x * settings.MaxSpeed;
            
            if(Mathf.Abs(input.y) > 0)
                state.Velocity.y += input.y * settings.MaxSpeed;
            
            
        }
        public static void Decelerate(ref Vector2 velocity, in Vector2 input, float deceleration, float deltaTime)
        {
            if(Mathf.Abs(input.x) < float.Epsilon)
            {
                if(velocity.x >= 0)
                {
                    velocity.x += (deceleration * deltaTime);
                    velocity.x = Mathf.Max(velocity.x, 0);
                }
                else
                {
                    velocity.x -= (deceleration * deltaTime);
                    velocity.x = Mathf.Min(velocity.x, 0);
                }

            }
            
            if(Mathf.Abs(input.y) < float.Epsilon)
            {
                if(velocity.y >= 0)
                {
                    velocity.y += (deceleration * deltaTime);
                    velocity.y = Mathf.Max(velocity.y, 0);
                }
                else
                {
                    velocity.y -= (deceleration * deltaTime);
                    velocity.y = Mathf.Min(velocity.y, 0);
                }
            }
        }

        public static void Decelerate(ref float velocity, in float input, float deceleration, float deltaTime)
        {
            if(Mathf.Abs(input) < float.Epsilon)
            {
                if(velocity >= 0)
                {
                    velocity += (deceleration * deltaTime);
                    velocity = Mathf.Max(velocity, 0);
                }
                else
                {
                    velocity -= (deceleration * deltaTime);
                    velocity = Mathf.Min(velocity, 0);
                }

            }
            
            
        }
        public static void FlipHorizontally(ref MovementState state, float movementValue)
        {
            state.isXFlipped = state.LocalScale.x < 0;
            bool willFlip = !state.isXFlipped && movementValue < 0 || state.isXFlipped && movementValue > 0;
            if (willFlip)
            {
                state.LocalScale = new Vector2(state.LocalScale.x * -1, state.LocalScale.y); 
            }

        }

        public static void FlipVertically(ref MovementState state, float movementValue)
        {
            state.isYFlipped = state.LocalScale.y < 0;
            bool willFlip = !state.isYFlipped && movementValue < 0 || state.isYFlipped && movementValue > 0;
            if (willFlip)
            {
                state.LocalScale = new Vector2(state.LocalScale.x, state.LocalScale.y * -1); 
            }

        }
        public static void SetScale(ref MovementState state, Vector3 scale)
        {
            state.LocalScale = scale;
        }
        public static void SetPosition(ref MovementState state, Vector3 position)
        {
            state.Position = position;
        }
    }
    [Serializable]
    public struct MovementState
    {
        public Vector3 Position;
        public Vector3 LocalScale;
        public bool isXFlipped;
        public bool isYFlipped;
        public Vector2 Velocity;
        public Vector2 Acceleration;
        
    }
    [Serializable]
    public struct MovementSettings
    {
        public float MaxSpeed;
        public float ZeroToMaxSpeed;
        public float MaxSpeedToZero;
        public float AccelerationRate => MaxSpeed / ZeroToMaxSpeed;
        public float DecelerationRate => -MaxSpeed / MaxSpeedToZero;
        public static MovementSettings Default = new MovementSettings()
        {
            MaxSpeed = 8,
            ZeroToMaxSpeed = 1,
            MaxSpeedToZero = 1
        };
    }
    [Serializable]
    public struct MovementInput 
    {
        public Vector2 MoveVector;
    }

    public struct MovementFlip
    {
        public bool isXFlipped;

    }
}
