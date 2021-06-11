using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace KaitoMajima
{
    public class ArrowDropdown : MonoBehaviour
    {
        [SerializeField] private List<string> optionNames = new List<string>();
        [SerializeField] private TextMeshProUGUI textComponent;
        private int currentOptionIndex;
        public UnityEvent<int> onValueChanged;

        private void Start()
        {
            ChangeText();
        }
        public void SubstituteOptions(List<string> optionNames)
        {
            this.optionNames = optionNames;
            ChangeText();
        }

        public void ChangeOption(int step)
        {
            currentOptionIndex += step;

            if(currentOptionIndex < 0) currentOptionIndex = optionNames.Count - 1;
            if(currentOptionIndex >= optionNames.Count) currentOptionIndex = 0;

            ChangeText();

        }

        public void SetOption(int index)
        {
            currentOptionIndex = index;
            ChangeText();
        }

        public void SetOptionWithoutNotify(int index)
        {
            currentOptionIndex = index;
            ChangeTextWithoutNotify();
        }

        private void ChangeText()
        {
            textComponent.text = optionNames[currentOptionIndex];
            onValueChanged?.Invoke(currentOptionIndex);
        }

        private void ChangeTextWithoutNotify()
        {
            textComponent.text = optionNames[currentOptionIndex];
        }
    }
}
