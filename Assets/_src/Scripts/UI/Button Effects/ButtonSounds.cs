using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KaitoMajima
{
    public class ButtonSounds : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ButtonInteractionSignaler buttonInteractions;
        [SerializeField] private SendAudio selectSound;
        [SerializeField] private SendAudio clickSound;

        private void Start()
        {
            buttonInteractions.onSelect += CallSelectSound;
            button.onClick.AddListener(CallClickSound);
        }
        private void CallSelectSound()
        {
            selectSound?.TriggerSound();
        }

        private void CallClickSound()
        {
            clickSound?.TriggerSound();
        }
        private void OnDestroy()
        {
            buttonInteractions.onSelect -= CallSelectSound;
            //button.onClick.RemoveListener(CallClickSound);
        }
    }
}
