using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace KaitoMajima
{
    public class SettingsNavigateInput : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private ButtonInteractionSignaler optionSetting;

        [SerializeField] private UnityEvent onPositiveInputCall;
        [SerializeField] private UnityEvent onNegativeInputCall;

        private InputAction navigateAction;
        private bool navigateActionHasListeners = false;

        private void Start()
        {
            optionSetting.onSelect += CallInputs;
            optionSetting.onDeselect += ForgetInputs;
        }

        private void CallInputs()
        {
            var UIActionMap = playerInput.actions.FindActionMap("UI");
            UIActionMap.Enable();

            navigateAction = UIActionMap.FindAction("Navigate");
            navigateAction.performed += ChangeSetting;
            navigateActionHasListeners = true;
        }

        private void ForgetInputs()
        {
            if(!navigateActionHasListeners) return;
            
            navigateAction.performed -= ChangeSetting;
            navigateActionHasListeners = false;
        }

        private void ChangeSetting(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();

            if(value.x == 0)
                return;
            
            if(value.x < -float.Epsilon) onNegativeInputCall?.Invoke();
            else if(value.x > float.Epsilon) onPositiveInputCall?.Invoke();

        }

        private void OnDisable()
        {
            ForgetInputs();
        }
        private void OnDestroy()
        {
            ForgetInputs();

            optionSetting.onSelect -= CallInputs;
            optionSetting.onDeselect -= ForgetInputs;
        }
    }
}
