using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Sirenix.OdinInspector;

namespace KaitoMajima
{
    public class MediatorTimelineIntegration : MonoBehaviour
    {
        [SerializeField] private PlayableDirector timeline;
        [SerializeField] private TransformReference initialTransformReference;
        [ReadOnly] [SerializeField] private TrackAsset trackAsset;
        [SerializeField] private bool assignMediatorOnStart = true;

        private Transform bindingTransform;
        private TimelineAsset timelineAsset;
        private System.Type bindingType;

        private void Start()
        {
            if(assignMediatorOnStart)
                AssignMediator(initialTransformReference);
        }

        private void AssignMediator(TransformReference transformReference)
        {
            var binding = timeline.GetGenericBinding(trackAsset);
            bindingType = binding.GetType();

            var mediatorTransform = transformReference.Value;
            if(!mediatorTransform.TryGetComponent(bindingType, out Component newBinding))
                return;
            timeline.SetGenericBinding(trackAsset, newBinding);
        }

        [Button("Get Track Asset By Index")]
        private void GetTrackAsset(int index)
        {
            timelineAsset = (TimelineAsset)timeline.playableAsset;
            trackAsset = timelineAsset.GetOutputTrack(index);
        }
    }
}
