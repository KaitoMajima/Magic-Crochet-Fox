using UnityEngine;

namespace KaitoMajima
{
    public interface IDetectionBehaviour
    {
        void Detect(ref MovementInput input);
    }
}
