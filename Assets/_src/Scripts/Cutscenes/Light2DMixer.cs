using UnityEngine;
using System.Collections;
using UnityEngine.Playables;
using UnityEngine.Experimental.Rendering.Universal;

public class Light2DMixer : PlayableBehaviour
{
    private Light2D light;
    private bool hasInitiated = false;

    private Color defaultLightColor;
    private float defaultIntensity;
    private float defaultMaxRadius;
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        light = playerData as Light2D;

        if (light == null) return;

        if (!hasInitiated)
        {
            defaultLightColor = light.color;
            defaultIntensity = light.intensity;
            defaultMaxRadius = light.pointLightOuterRadius;

            hasInitiated = true;
        }
           

        Color blendColor = Color.clear;
        float blendIntensity = 0;
        float blendMaxRadius = 0;
        float totalWeight = 0;

        int inputCount = playable.GetInputCount();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);

            ScriptPlayable<Light2DBehaviour> inputPlayable = (ScriptPlayable<Light2DBehaviour>)playable.GetInput(i);

            Light2DBehaviour lightBehaviour = inputPlayable.GetBehaviour();

            blendColor += lightBehaviour.lightColor * inputWeight;
            blendIntensity += lightBehaviour.intensity * inputWeight;
            blendMaxRadius += lightBehaviour.maxRadius * inputWeight;

            totalWeight += inputWeight;

        }

        float remainingWeight = 1 - totalWeight;

        light.color = blendColor + defaultLightColor * remainingWeight;
        light.intensity = blendIntensity + defaultIntensity * remainingWeight;
        light.pointLightOuterRadius = blendMaxRadius + defaultMaxRadius * remainingWeight;

    }

    public override void OnPlayableDestroy(Playable playable)
    {
        hasInitiated = false;

        if (light == null)
            return;

        light.color = defaultLightColor;
        light.intensity = defaultIntensity;
        light.pointLightOuterRadius = defaultMaxRadius;
    }
}
