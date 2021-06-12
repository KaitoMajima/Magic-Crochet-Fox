using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            OnWeaponUse?.Invoke();
            
            var projObj = Instantiate(projectilePrefab, bulletFirePoint.position, 
            Quaternion.FromToRotation(Vector2.right, target.position - bulletFirePoint.position));

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
        }
    }
}