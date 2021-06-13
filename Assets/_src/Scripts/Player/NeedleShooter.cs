using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace KaitoMajima
{
    public class NeedleShooter : Weapon
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private TransformReference dynamicPlayerInputReference;

        [SerializeField] private Camera mainCamera;
        [SerializeField] private TransformReference dynamicCameraReference;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform bulletFirePoint;
        [SerializeField] private Transform shooterHolder;
        [SerializeField] private TransformReference reticleTarget;
        [SerializeField] private int needleMaxCount;
        private int currentNeedleCount;

        public static Action onRetrieveNeedle;

        public Action<int> onNeedleCountChanged;
        [SerializeField] private UnityEvent onShoot;


        private InputAction fireAction;
        private InputAction aimAction;
        public Vector2 RawMousePosition { get; private set; }

        private void Start()
        {
            if(playerInput == null)
                playerInput = dynamicPlayerInputReference.Value.GetComponent<PlayerInput>();
            
            if(mainCamera == null)
                mainCamera = dynamicCameraReference.Value.GetComponent<Camera>();
            
            var playerActionMap = playerInput.actions.FindActionMap("Player");

            aimAction = playerActionMap.FindAction("Aim");
            aimAction.performed += InputMousePosition;

            fireAction = playerActionMap.FindAction("Fire");
            fireAction.performed += PullTrigger;
            fireAction.canceled += ReleaseTrigger;

            currentNeedleCount = needleMaxCount;
            onNeedleCountChanged?.Invoke(currentNeedleCount);

            onRetrieveNeedle += AddNeedle;
        }

        private void AddNeedle()
        {
            currentNeedleCount++;
            onNeedleCountChanged?.Invoke(currentNeedleCount);
        }

        private void InputMousePosition(InputAction.CallbackContext context)
        {
            RawMousePosition = context.ReadValue<Vector2>();
        }
        private void PullTrigger(InputAction.CallbackContext context)
        {
            Use(reticleTarget.Value);
        }

        private void ReleaseTrigger(InputAction.CallbackContext context)
        {
            Stop();
        }
        public override void Use(Transform target)
        {
            if(currentNeedleCount <= 0)
                return;
            
            currentNeedleCount--;
            onNeedleCountChanged?.Invoke(currentNeedleCount);
            OnWeaponUse?.Invoke();
            
            var projObj = Instantiate(projectilePrefab, bulletFirePoint.position, 
            Quaternion.FromToRotation(Vector2.right, target.position - bulletFirePoint.position));

            onShoot?.Invoke();

            var projScript = projObj.GetComponent<Projectile>();
            projScript.originalHolder = transform;
            IsFiring = true;

        }

        public override void Stop()
        {
            IsFiring = false;
        }
        
        private void OnDestroy()
        {
            fireAction.performed -= PullTrigger;
            fireAction.canceled -= ReleaseTrigger;

            onRetrieveNeedle -= AddNeedle;
        }
    }
}
