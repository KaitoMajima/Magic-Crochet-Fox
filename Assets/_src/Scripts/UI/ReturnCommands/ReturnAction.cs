using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public abstract class ReturnAction : MonoBehaviour
    {
        [SerializeField] private SendAudio returnSound;
        [SerializeField] private NextSelectedButton nextButton;
        public virtual void Return() 
        {
            returnSound?.TriggerSound();
            nextButton.Connect();
            
        }


    }
}
