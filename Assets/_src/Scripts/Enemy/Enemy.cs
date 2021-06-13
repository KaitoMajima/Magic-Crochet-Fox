using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class Enemy : MonoBehaviour, IActor
    {
        public enum EnemyState
        {
            Idle,
            Attached
        }
        [SerializeField] public EnemyState enemyState;

        public void Attach()
        {
            enemyState = EnemyState.Attached;
        }
        public void Unattach()
        {
            enemyState = EnemyState.Idle;
        }
    }
}
