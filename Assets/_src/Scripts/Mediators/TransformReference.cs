using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    [CreateAssetMenu(menuName = "Mediators/Transform")]
    public class TransformReference : ScriptableObject
    {
        public Transform Value;
    }
}
