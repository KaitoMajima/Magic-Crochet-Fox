using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private int damage;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(!col.TryGetComponent(out Player player))
                return;
            
            player.TryTakeDamage(damage, enemy);
        }
    }
}
