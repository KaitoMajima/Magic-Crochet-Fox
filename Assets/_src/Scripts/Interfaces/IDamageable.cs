using System;
using UnityEngine;

namespace KaitoMajima
{
    public interface IDamageable
    {
        Action<int, IActor> OnDamageTaken {get; set;}
        bool TryTakeDamage(int damage, IActor actor);
    }
}