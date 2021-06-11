using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace KaitoMajima
{
    
    public class InteractionHandler : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;

        [SerializeField] [ReadOnly] private List<Collider2D> targets = new List<Collider2D>();

        private TriggeredInteraction selectedInteractable;
        private InputAction interactAction;

        private void Start()
        {
            targets.Clear();

            if(playerInput == null)
                return;
            var playerActionMap = playerInput.actions.FindActionMap("Player");
            playerActionMap.Enable();

            interactAction = playerActionMap.FindAction("Interact");
            interactAction.performed += Interact;

        }

        private void Interact(InputAction.CallbackContext ctx)
        {
            if(playerInput == null)
                return;
            if (selectedInteractable == null)
                return;
            selectedInteractable.OnInteract();
        }
        private bool ReturnToPreviousSelected()
        {
            if(targets.Count == 0)
                return false;
            
            var target = targets[targets.Count - 1];
            if(target != null)
            {
                if(!target.TryGetComponent(out TriggeredInteraction interaction))
                    return false;

                selectedInteractable = interaction;
                selectedInteractable.OnAreaEnter();
            }
            return true;

        }
        private void ExitRemainingAreas(Collider2D collider)
        {
            foreach (var target in targets)
            {
                if(target == collider)
                    return;
                
                if(!target.TryGetComponent(out TriggeredInteraction interaction))
                    return;
            
                interaction.OnAreaExit();
            }
        }
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(!collider.TryGetComponent(out TriggeredInteraction interaction))
                return;
            
            selectedInteractable = interaction;
            selectedInteractable.OnAreaEnter();
            targets.Add(collider);
            ExitRemainingAreas(collider);
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if(!collider.TryGetComponent(out TriggeredInteraction interaction))
                return;
            
            interaction.OnAreaExit();
            targets.Remove(collider);

            if(!ReturnToPreviousSelected())
                selectedInteractable = null;
            
        }

        private void OnDestroy()
        {
            if(playerInput == null)
                return;
            interactAction.performed -= Interact;

        }
    }

}