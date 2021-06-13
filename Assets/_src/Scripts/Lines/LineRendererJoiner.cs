using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class LineRendererJoiner : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;

        [SerializeField] private Transform lineTransformA;

        [SerializeField] private TransformReference refForTransformB;
        [SerializeField] private Transform lineTransformB;

        [SerializeField] private float lineStartWidth = 0.1f;
        [SerializeField] private float lineEndWidth = 0.1f;
        private List<Vector3> endsPositions;

        private void Start()
        {
            endsPositions = new List<Vector3>();

            if(refForTransformB != null)
                lineTransformB = refForTransformB.Value;
            
            endsPositions.Add(lineTransformA.position);
            endsPositions.Add(lineTransformB.position);

            lineRenderer.startWidth = lineStartWidth;
            lineRenderer.endWidth = lineEndWidth;
            lineRenderer.SetPositions(endsPositions.ToArray());
            lineRenderer.useWorldSpace = true;


        }

        private void Update()
        {
            endsPositions.Clear();
            endsPositions.Add(lineTransformA.position);
            endsPositions.Add(lineTransformB.position);
            lineRenderer.SetPositions(endsPositions.ToArray());
        }
    }
}
