using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class TabGroup : MonoBehaviour
    {
        private List<TabButton> tabButtons;
        [SerializeField] private PageGroup pageGroup;
        
        private TabButton selectedTab;
        public TabButton SelectedTab {get => selectedTab; set => selectedTab = value;}
        void Awake()
        {
            tabButtons = new List<TabButton>();
        }

        public void Subscribe(TabButton button)
        {
            tabButtons.Add(button);
        }

        public void OnTabEnter(TabButton button)
        {

        }

        public void OnTabExit(TabButton button)
        {

        }

        public void OnTabSelected(TabButton button)
        {
            selectedTab = button;

            int buttonIndex = button.transform.GetSiblingIndex();

            pageGroup.SetSelectedPage(buttonIndex);

        }
        
    }
}
