using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class Light2DClip : PlayableAsset
{
    [SerializeField]
    private Light2DBehaviour template = new Light2DBehaviour();

    public ClipCaps clipCaps {get { return ClipCaps.Blending;  } }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<Light2DBehaviour>.Create(graph, template);
    }
}
