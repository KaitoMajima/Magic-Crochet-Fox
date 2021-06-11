using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Timeline;


[TrackColor(241f/255f, 249f/255f, 99f/255f)]
[TrackBindingType(typeof(Light2D))]
[TrackClipType(typeof(Light2DClip))]
public class Light2DTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<Light2DMixer>.Create(graph, inputCount);
    }
}
