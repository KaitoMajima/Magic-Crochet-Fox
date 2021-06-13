using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;
using Sirenix.OdinInspector;

namespace KaitoMajima
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private TransformReference playerReference;
        private Player player;
        [SerializeField] private Image barFill;
        [SerializeField] private Image barDamage;
        [SerializeField] private TMP_Text healthValue;

        [SerializeField] private float barDamageFreezeTime = 0.5f;
        [SerializeField] private float barDamageShrinkSpeed = 1;
        private float barDamageTimer;
        private IEnumerator damagedTimer;

        private void Start()
        {
            player = playerReference.Value.GetComponent<Player>();

            SetHealth(player.healthState.Health, player.healthState.MaxHealth);
            barDamage.fillAmount = barFill.fillAmount;

            player.OnDamageTaken += InflictDamage;
        }
        private void InflictDamage(int damage, IActor actor)
        {
            if (damagedTimer != null)
                StopCoroutine(damagedTimer);
            damagedTimer = DamagedTimer();
            StartCoroutine(damagedTimer);
            SetHealth(player.healthState.Health, player.healthState.MaxHealth);
        }
        private void SetHealth(int health, int maxHealth)
        {
            barFill.fillAmount = GetNormalizedHealth(health, maxHealth);
            healthValue.text = $"{health.ToString()}/{maxHealth.ToString()}";
        }

        private float GetNormalizedHealth(int currentHealth, int maxHealth)
        {
            return (float)currentHealth / maxHealth;
        }

        private IEnumerator DamagedTimer()
        {
            barDamageTimer = barDamageFreezeTime;
            yield return new WaitForSeconds(barDamageTimer);
            while (true) 
            {

                if(barFill.fillAmount < barDamage.fillAmount)
                {
                    barDamage.fillAmount -= barDamageShrinkSpeed * Time.deltaTime;
                    yield return null;
                }
                else
                {
                    break;
                }
                
            }

        }
        
    }

}
