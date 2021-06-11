using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace KaitoMajima
{
    public class SkippableClip : PlayableAsset
    {
        public bool clipPausesAtEnd;
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<SkippableBehaviour>.Create(graph);

            SkippableBehaviour skippableBehaviour = playable.GetBehaviour();
            skippableBehaviour.clipPausesAtEnd = clipPausesAtEnd;

            return playable;
        }
    }
}

