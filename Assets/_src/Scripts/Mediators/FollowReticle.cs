using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KaitoMajima
{
    public class FollowReticle : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private TransformReference dynamicPlayerInputReference;
        
        [SerializeField] private Transform reticleTransform;

        [SerializeField] private Camera mainCamera;
        [SerializeField] private TransformReference dynamicCameraReference;
        private Vector2 mousePosition;
        private InputAction aimAction;

        public Vector2 RawMousePosition {get; private set;}

        private void Start()
        {
            if(playerInput == null)
                playerInput = dynamicPlayerInputReference.Value.GetComponent<PlayerInput>();
            
            if(mainCamera == null)
                mainCamera = dynamicCameraReference.Value.GetComponent<Camera>();
            
            var playerActionMap = playerInput.actions.FindActionMap("Player");

            aimAction = playerActionMap.FindAction("Aim");
            aimAction.performed += InputMousePosition;
        }

        private void InputMousePosition(InputAction.CallbackContext context)
        {
            RawMousePosition = context.ReadValue<Vector2>();
        }

        private void LateUpdate()
        {
            mousePosition = mainCamera.ScreenToWorldPoint(RawMousePosition);
            reticleTransform.position = mousePosition;
        }

    }
}
