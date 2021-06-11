using UnityEngine;
using System.Collections;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System;

[Serializable]
public class Light2DBehaviour : PlayableBehaviour
{
    public Color lightColor = Color.white;
    public float intensity = 1f;
    public float maxRadius = 5f;
}
