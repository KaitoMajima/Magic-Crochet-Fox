using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class ReturnScreen : ReturnAction
    {
        [SerializeField] private GameObject screenToHide;
        [SerializeField] private GameObject screenToShow;
        public override void Return()
        {
            if(screenToHide != null)
                screenToHide.SetActive(false);
            if(screenToShow != null)
                screenToShow.SetActive(true);
            base.Return();
            
        }
    }
}
