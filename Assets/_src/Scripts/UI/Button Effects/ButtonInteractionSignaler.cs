using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace KaitoMajima
{
    public class ButtonInteractionSignaler : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        public Action onSelect;
        public Action onDeselect;
        
        public void OnSelect(BaseEventData eventData)
        {
            onSelect?.Invoke();
        }
        public void OnDeselect(BaseEventData eventData)
        {
            onDeselect?.Invoke();
        }
    }
}
