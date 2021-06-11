using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace KaitoMajima
{
    [TrackColor(21f / 255f, 20f / 255f, 241f / 255f)]
    [TrackBindingType(typeof(SkippableHandler))]
    [TrackClipType(typeof(SkippableClip))]
    public class SkippableTrack : TrackAsset
    {

    }
}

