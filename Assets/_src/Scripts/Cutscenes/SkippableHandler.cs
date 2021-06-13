using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

namespace KaitoMajima
{
    
    public class SkippableHandler : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private TransformReference dynamicPlayerInputReference;
        private InputMaster controls;
        
        public UnityEvent OnSkipTriggered;
        public Action OnAnimationSkipped;
        private InputAction advanceAction;

        private void Start()
        {
            if(playerInput == null)
                playerInput = dynamicPlayerInputReference.Value.GetComponent<PlayerInput>();
            
            var uiActionMap = playerInput.actions.FindActionMap("UIExtra");
            uiActionMap.Enable();

            advanceAction = uiActionMap.FindAction("Advance");
            advanceAction.performed += SkipAnimation;

            SkippableBehaviour.onSkippingClip += OnClipSkip;
        }

        private void OnClipSkip()
        {
            //OnSkipTriggered?.Invoke();
        }

        private void SkipAnimation(InputAction.CallbackContext context)
        {
            OnAnimationSkipped?.Invoke();
        }
        private void OnDestroy()
        {
            advanceAction.performed -= SkipAnimation;
            SkippableBehaviour.onSkippingClip -= OnClipSkip;
        }

    }

}