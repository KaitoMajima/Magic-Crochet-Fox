using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KaitoMajima
{
    public class AttachTarget : MonoBehaviour
    {
        [SerializeField] private SpringJoint2D springJoint;

        [SerializeField] private ProjectileCollisionIgnorer collisionIgnorer;

        [Space]
        public UnityEvent onAttachmentFired;
        public UnityEvent onAttachmentReleased;

        public void SetAttachmentTo(Transform holderTransform)
        {
            springJoint.enabled = true;
            var holderRigidbody = holderTransform.GetComponent<Rigidbody2D>();
            springJoint.connectedBody = holderRigidbody;

            collisionIgnorer.activated = true;
            onAttachmentFired?.Invoke();
        }

        public void UnsetAttachments()
        {
            collisionIgnorer.activated = false;
            
            springJoint.connectedBody = null;
            springJoint.enabled = false;
            onAttachmentReleased?.Invoke();
        }
    }
}
