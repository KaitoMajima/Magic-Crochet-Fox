using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KaitoMajima
{
    public class ReturnerProcessor : SerializedMonoBehaviour
    {
        public Stack<ReturnAction> returnActions;

        [SerializeField] private PlayerInput playerInput;
        private InputAction backAction;

        private void Start()
        {
            var UIActionMap = playerInput.actions.FindActionMap("UIExtra");
            UIActionMap.Enable();

            backAction = UIActionMap.FindAction("Back");
            backAction.performed += CallReturn;
        }

        public void CallReturn(InputAction.CallbackContext context)
        {
            Return();
        }

        public void Return()
        {
            if(returnActions.Count == 0) return;
            var returnAction = returnActions.Peek();

            returnAction.Return();
        }

        public void Subscribe(ReturnAction returnAction)
        {
            if(returnActions == null)
                Clear();
            returnActions.Push(returnAction);
        }

        public void Pop()
        {
            returnActions.Pop();
        }

        public void Clear()
        {
            returnActions = new Stack<ReturnAction>();
        }

        private void OnDisable()
        {
            Clear();
        }
        private void OnDestroy()
        {
            backAction.performed -= CallReturn;
        }
    }
}
