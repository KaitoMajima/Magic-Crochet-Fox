using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KaitoMajima
{
    public class UnityToggleSwitch : MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
        public void Switch()
        {
            toggle.Switch();
        }

        public void SwitchWithoutNotify()
        {
            toggle.SwitchWithoutNotify();
        }
    }
}
