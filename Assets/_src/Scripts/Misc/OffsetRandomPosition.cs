using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class OffsetRandomPosition : MonoBehaviour
    {
        [SerializeField] private Transform transformToOffset;
        [SerializeField] private Vector2 horizontalRangeOffset;
        [SerializeField] private Vector2 verticalRangeOffset;
        private void Start()
        {
            transformToOffset.position = new Vector2(transformToOffset.position.x + Random.Range(horizontalRangeOffset.x, horizontalRangeOffset.y), 
            transformToOffset.position.y + Random.Range(verticalRangeOffset.x, verticalRangeOffset.y));

        }

        
    }
}
