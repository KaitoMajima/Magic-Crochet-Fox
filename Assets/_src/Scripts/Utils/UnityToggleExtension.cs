using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KaitoMajima
{
    public static class UnityToggleExtension
    {
        public static void Switch(this Toggle toggle)
        {
            toggle.isOn = !toggle.isOn;
        }

        public static void SwitchWithoutNotify(this Toggle toggle)
        {
            toggle.SetIsOnWithoutNotify(!toggle.isOn);
        }
    }
}
