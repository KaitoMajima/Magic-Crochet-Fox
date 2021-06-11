using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace KaitoMajima
{
    public class PauseController : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private TransformReference dynamicPlayerInputReference;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private UnityEvent onPause;
        private bool pauseActivated = false;
        private InputActionMap playerMap;
        private InputActionMap pauseMap;
        private InputAction pauseAction;
        private bool canPause = true;

        public static Action<bool> onPauseTriggered;

        private void Start()
        {
            if(playerInput == null)
                playerInput = dynamicPlayerInputReference.Value.GetComponent<PlayerInput>();
            
            pauseMap = playerInput.actions.FindActionMap("UIExtra");
            playerMap = playerInput.actions.FindActionMap("Player");

            pauseMap.Enable();
            playerMap.Enable();

            pauseAction = pauseMap.FindAction("Pause");
            pauseAction.performed += Pause;
        }

        private void Pause(InputAction.CallbackContext context)
        {
            if(!canPause)
                return;
            pauseActivated = !pauseActivated;
            onPauseTriggered?.Invoke(pauseActivated);
            pauseMenu.SetActive(pauseActivated);

            if(pauseActivated)
                PauseStop();
            if(!pauseActivated)
                PauseRelease();
        }

        
        public void Pause()
        {
            if(!canPause)
                return;
            pauseActivated = !pauseActivated;
            pauseMenu.SetActive(pauseActivated);

            if(pauseActivated)
                PauseStop();
            if(!pauseActivated)
                PauseRelease();
        }

        private void PauseStop()
        {
            Time.timeScale = 0;
            playerMap.Disable();
            onPause?.Invoke();
        }

        private void PauseRelease()
        {
            Time.timeScale = 1;
            playerMap.Enable();
        }
        public void RestraintPause(bool shouldPause)
        {
            canPause = shouldPause;
        }
        public void ReloadScene()
        {
            SceneManager.LoadScene(gameObject.scene.name);
        }
        private void OnDestroy()
        {
            PauseRelease();
            pauseAction.performed -= Pause;
        }
    }
}
