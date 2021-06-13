using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KaitoMajima
{
    public class NeedleCounter : MonoBehaviour
    {
        [SerializeField] private TransformReference playerReference;

        [SerializeField] private TextMeshProUGUI textComponent;
        private NeedleShooter playerNeedleShooter;
        private void Awake()
        {
            playerNeedleShooter = playerReference.Value.GetComponent<NeedleShooter>();
            playerNeedleShooter.onNeedleCountChanged += ChangeText;
        }

        private void ChangeText(int amount)
        {
            textComponent.text = amount.ToString();
        }

        private void OnDestroy()
        {
            playerNeedleShooter.onNeedleCountChanged -= ChangeText;
            
        }
    }
}
