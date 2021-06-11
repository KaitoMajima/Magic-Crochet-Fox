using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace KaitoMajima
{
    public class SettingsSubmitInput : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private ButtonInteractionSignaler optionSetting;

        [SerializeField] private UnityEvent onInputCall;

        private InputAction submitAction;
        private bool submitActionHasListeners;

        private void Start()
        {
            optionSetting.onSelect += CallInputs;
            optionSetting.onDeselect += ForgetInputs;
        }

        private void CallInputs()
        {
            var UIActionMap = playerInput.actions.FindActionMap("UI");
            UIActionMap.Enable();

            submitAction = UIActionMap.FindAction("Submit");
            submitAction.performed += ChangeSetting;
            submitActionHasListeners = true;

        }

        private void ForgetInputs()
        {
            if(!submitActionHasListeners) return;
            submitAction.performed -= ChangeSetting;
            submitActionHasListeners = false;
        }

        private void ChangeSetting(InputAction.CallbackContext context)
        {
            onInputCall?.Invoke();
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
