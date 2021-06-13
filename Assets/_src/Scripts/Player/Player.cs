using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;
using Sirenix.OdinInspector;
using UnityEngine.Events;
using UnityEngine.Playables;

namespace KaitoMajima
{
    public class Player : MonoBehaviour, IActor, IDamageable
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Rigidbody2D playerRigidbody;
        [SerializeField] private Transform groundDetectionTransform;
        [SerializeField] private TweenController[] damageAnimation;
        [SerializeField] private PlayableDirector deathCutscene;


        [SerializeField] private float groundDetectionRadius;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float maxFallToleration = 0.4f;
        private bool isGrounded;
        private bool wasGrounded;
        private Coroutine fallingCoroutine;
        private MovementState movementState;
        private MovementInput moveInput;
        [SerializeField] private MovementSettings movementSettings = MovementSettings.Default;
        public HealthState healthState = HealthState.Default;
        public enum PlayerState
        {
            Idle,
            Sneezing,
            Death
        }
        private InputAction movementAction;
        [HideInInspector] public Action<HealthState> OnHealthChanged;

        private InputAction aimAction;

        [HideInInspector] public Action<int, IActor> OnDamageTaken {get; set;}

        public UnityEvent OnDamage;
        private InputActionMap playerActionMap;

        private void Start()
        {
            playerActionMap = playerInput.actions.FindActionMap("Player");
            playerActionMap.Enable();

            movementAction = playerActionMap.FindAction("Movement");
            movementAction.performed += InputMovement;


            healthState.Health = healthState.MaxHealth;
        }

        private void Update()
        {
            isGrounded = Physics2D.OverlapCircle(
            groundDetectionTransform.position, 
            groundDetectionRadius,
            groundMask);

            bool gettingOffGround = wasGrounded && !isGrounded;
            if(gettingOffGround)
                fallingCoroutine = StartCoroutine(InitiateFall(maxFallToleration));
            
            bool gettingBackOnGround = !wasGrounded && isGrounded;
            if(gettingBackOnGround)
                CancelFall();
            wasGrounded = isGrounded;
        }
        private void FixedUpdate()
        {
 
            Movement.Move(ref movementState, movementSettings, moveInput, Time.deltaTime);
            playerRigidbody.MovePosition((Vector2)transform.position + movementState.Velocity);
       
            Movement.SetPosition(ref movementState, transform.position);
        }
        private void InputMovement(InputAction.CallbackContext context)
        {
            moveInput.MoveVector = context.ReadValue<Vector2>();  
        }

        private IEnumerator InitiateFall(float seconds)
        {
            while (seconds > 0)
            {
                seconds -= Time.deltaTime;
                yield return null;
            }
            Fall();

            fallingCoroutine = null;
        }

        private void CancelFall()
        {
            if(fallingCoroutine == null)
                return;

            StopCoroutine(fallingCoroutine);
        }

        private void Fall()
        {
            Debug.Log("Falling!");
        }
        public bool TryTakeDamage(int damage, IActor actor)
        {
            Health.Damage(ref healthState, damage);

            OnHealthChanged?.Invoke(healthState);
            OnDamageTaken?.Invoke(damage, actor); 
            OnDamage?.Invoke();

            if(healthState.Health <= 0)
            {
                healthState.Health = 0;
                Die();
            }
            else
            {
                foreach (var animation in damageAnimation)
                {
                    animation.Activate();
                }
            }
            
            return true;
        }

        private void Die()
        {
            moveInput.MoveVector = Vector2.zero;
            movementState.Velocity = Vector2.zero;
            playerRigidbody.simulated = false;

            playerActionMap.Disable();
            deathCutscene?.Play();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawWireSphere(groundDetectionTransform.position, groundDetectionRadius);
        }


        #region Signal Receiver Methods
        public void ActivatePlayerControls()
        {
            movementAction?.Enable();
        }

        public void DeactivatePlayerControls()
        {
            movementAction?.Disable();
            movementState.Velocity = Vector2.zero;
            moveInput.MoveVector = Vector2.zero;
        }

        #endregion
    }
}
