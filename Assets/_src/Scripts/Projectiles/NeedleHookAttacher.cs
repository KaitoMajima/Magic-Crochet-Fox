using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class NeedleHookAttacher : MonoBehaviour
    {
        [SerializeField] private Projectile projectile;

        private void Start()
        {
            projectile.onProjectileContact += Attach;
        }

        private void Attach(Projectile.ProjectileContactData data)
        {
            var attachTargetScript = data.targetHit.GetComponent<AttachTarget>();
            attachTargetScript.SetAttachmentTo(data.originalHolder);
        }

        private void OnDestroy()
        {
            projectile.onProjectileContact -= Attach;
        }
    }
}
