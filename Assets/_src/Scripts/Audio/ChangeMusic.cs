using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class ChangeMusic : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;

        [SerializeField] private AudioSource audioSource;

        public void Change()
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
