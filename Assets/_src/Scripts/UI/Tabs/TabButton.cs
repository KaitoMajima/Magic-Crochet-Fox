using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KaitoMajima
{
    public class TabButton : MonoBehaviour
    {
        [SerializeField] private TabGroup tabGroup;
        [SerializeField] private Button button;
        [SerializeField] private ButtonInteractionSignaler buttonInteractions;


        private void Start()
        {
            tabGroup.Subscribe(this);
            buttonInteractions.onSelect += OnButtonSelected;
            buttonInteractions.onDeselect += OnButtonSelected;
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonSelected()
        {
            tabGroup.OnTabEnter(this);
        }

        private void OnButtonDeselected()
        {
            tabGroup.OnTabExit(this);
        }

        private void OnButtonClicked()
        {
            tabGroup.OnTabSelected(this);
        }

        private void OnDestroy()
        {
            buttonInteractions.onSelect -= OnButtonSelected;
            buttonInteractions.onDeselect -= OnButtonSelected;
            button.onClick.RemoveListener(OnButtonClicked);
        }
    }
}
