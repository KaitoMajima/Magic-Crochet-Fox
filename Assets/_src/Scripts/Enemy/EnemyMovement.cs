using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private AttachTarget attachTarget;

        [SerializeField] private Rigidbody2D enemyRigidbody;

        [SerializeField] private MovementState movementState;
        [SerializeField] private MovementSettings movementSettings = MovementSettings.Default;

        [SerializeField] private MovementInput movementInput;

        [SerializeField] private float detectionRadius;

        [SerializeField] private LayerMask playerMask;
        private bool canFollow = true;

        private void Start()
        {
            attachTarget.onAttachmentFired.AddListener(BlockMovement);
            attachTarget.onAttachmentReleased.AddListener(ReleaseMovement);
        }

        private void Update()
        {
            if(!canFollow)
                return;
            
            var resultCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerMask);
            if(resultCollider == null)
            {
                movementInput.MoveVector = Vector2.zero;
                return;
            }
    
            var targetTransform = resultCollider.transform;

            movementInput.MoveVector = (targetTransform.position - transform.position).normalized;
        }

        private void FixedUpdate()
        {
            
       
            Movement.SetPosition(ref movementState, transform.position);
            if(!canFollow)
                return;
            Movement.Move(ref movementState, movementSettings, movementInput, Time.deltaTime);
            enemyRigidbody.MovePosition((Vector2)transform.position + movementState.Velocity);
        }
        public void BlockMovement()
        {
            canFollow = false;
        }
        public void ReleaseMovement()
        {
            canFollow = true;
        }

        private void OnDestroy()
        {
            attachTarget.onAttachmentFired.RemoveListener(BlockMovement);
            attachTarget.onAttachmentReleased.RemoveListener(ReleaseMovement);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}
