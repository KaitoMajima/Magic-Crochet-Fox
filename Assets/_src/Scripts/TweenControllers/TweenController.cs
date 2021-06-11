using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public abstract class TweenController : MonoBehaviour
    {
        public enum PlayOnEnableTween
        {
            None,
            Activate,
            Deactivate
        }
        public virtual void Activate()
        {

        }

        public virtual void Deactivate()
        {

        }
    }
}
