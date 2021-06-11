using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class ReturnPage : ReturnAction
    {
        [SerializeField] private PageGroup pageGroup;
        public override void Return()
        {
            pageGroup.ClearPages();
            base.Return();
    
        }
    }
}
