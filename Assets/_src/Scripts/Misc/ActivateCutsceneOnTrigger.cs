using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace KaitoMajima
{
    public class ActivateCutsceneOnTrigger : MonoBehaviour
    {
        [SerializeField] private PlayableDirector timeline;

        private bool hasTriggered;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(hasTriggered)
                return;
            if(!other.TryGetComponent(out Player player))
                return;

            hasTriggered = true;
            timeline.Play();
        }
    }
}
