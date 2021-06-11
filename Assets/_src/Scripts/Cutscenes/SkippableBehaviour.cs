using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.Threading.Tasks;
using System;

namespace KaitoMajima
{
    
    public class SkippableBehaviour : PlayableBehaviour
    {
        private bool clipIsPlaying = false;
        private bool canPauseTimeline = false;
        private bool unpauseRequest = false;
        private PlayableDirector timeline;
        public bool clipPausesAtEnd;
        public SkippableHandler skippableHandler;
        private float waitSeconds;
        private double playablePreviousTime;
        private double playableDuration;

        public static Action onSkippingClip;

        public override void OnPlayableCreate(Playable playable)
        {
            timeline = playable.GetGraph().GetResolver() as PlayableDirector;

            Wait(0.1f);

        }
        public override void OnPlayableDestroy(Playable playable)
        {
            skippableHandler.OnAnimationSkipped -= SkipClip;
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            playablePreviousTime = playable.GetPreviousTime();
            playableDuration = playable.GetDuration();

            if (skippableHandler == null)
                skippableHandler = playerData as SkippableHandler;

            if (clipIsPlaying)
                return;

            if (info.weight > 0)
            {
                clipIsPlaying = true;
                skippableHandler.OnAnimationSkipped += SkipClip;
            }


        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            
            if (canPauseTimeline)
            {
                
                if (Application.isPlaying)
                {
                    if (!unpauseRequest && clipPausesAtEnd)
                    {
                        PauseTimeline(timeline);
                    }
                        
                }


                playablePreviousTime = 0;
                playableDuration = 0;
            }

        }

        private async void Wait(float seconds)
        {
            waitSeconds = seconds;

            while (waitSeconds > 0)
            {
                waitSeconds -= Time.unscaledDeltaTime;
                await Task.Yield();
            }

            canPauseTimeline = true;
        }

        private void SkipClip()
        {
            
            bool atClipEnd = playableDuration == 0 && playablePreviousTime == 0;
            if (atClipEnd)
            {
                double timelineSpeed = timeline.playableGraph.GetRootPlayable(0).GetSpeed();
                if(timelineSpeed == 0)
                    onSkippingClip.Invoke();
                ResumeTimeline(timeline);
                return;
            }
            unpauseRequest = true;
            timeline.time += playableDuration - playablePreviousTime;
            timeline.Evaluate();
            onSkippingClip.Invoke();
        }

        public void ResumeTimeline(PlayableDirector timeline)
        {
            timeline.playableGraph.GetRootPlayable(0).SetSpeed(1);
        }
        public void PauseTimeline(PlayableDirector timeline)
        {
            timeline.playableGraph.GetRootPlayable(0).SetSpeed(0);
        }
    }

}