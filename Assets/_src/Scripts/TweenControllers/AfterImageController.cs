using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class AfterImageController : TweenController
    {
        [SerializeField]
        private AfterImageState afterImageState;

        [SerializeField]
        private GameObject afterImagePrefab;

        [SerializeField]
        private Transform instantiateTransform;

        public Transform InstantiateTransform {get => instantiateTransform; set => instantiateTransform = value; }

        [SerializeField]
        private PlayOnEnableTween playOnEnable = PlayOnEnableTween.None;

        [SerializeField]
        private bool timerIsInclusive;
        [SerializeField]
        private AfterImageSettings afterImageSettings = AfterImageSettings.Default;

        public Action<GameObject> OnAfterImageInstantiated;

        private void OnEnable()
        {
            if(playOnEnable == PlayOnEnableTween.Activate)
                Activate();
        }
        public override void Activate()
        {
            AfterImage.InitiateAfterImages(ref afterImageState, afterImageSettings);
            if(timerIsInclusive)
                InstantiateAfterImage();

            StartCoroutine(AfterImagesTimer());
        }

        private void InstantiateAfterImage()
        {
            GameObject afterImage;
            if(instantiateTransform == null) 
                afterImage = Instantiate(afterImagePrefab, transform.position, Quaternion.identity);
            else 
                afterImage = Instantiate(afterImagePrefab, instantiateTransform.position, Quaternion.identity, instantiateTransform);
            
            AfterImage.InstantiateAfterImage(ref afterImageState, afterImageSettings);
            OnAfterImageInstantiated?.Invoke(afterImage);

        }
        private IEnumerator AfterImagesTimer()
        {
            if(afterImageState.overallAfterImageTimer <= 0)
                yield break;
            
            while(afterImageState.singleAfterImageTimer > 0)
            {
                afterImageState.singleAfterImageTimer -= Time.deltaTime;
                afterImageState.overallAfterImageTimer -= Time.deltaTime;
                yield return null;
            }

            InstantiateAfterImage();

            if(afterImageState.overallAfterImageTimer > 0)
                StartCoroutine(AfterImagesTimer());
        }
    }
}
