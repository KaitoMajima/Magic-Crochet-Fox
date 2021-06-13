using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class IslandCheckpoint : MonoBehaviour
    {
        [SerializeField] private Transform checkpoint;
        public Transform Checkpoint { get => checkpoint; private set => checkpoint = value; }

    }
}
