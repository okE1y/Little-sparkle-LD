using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] public Transform entry;
    [SerializeField] public Transform end;
    [SerializeField] public List<Transform> nodes = new List<Transform>();

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2 + nodes.Count;

        if (nodes.Count != 0)
        {
            lineRenderer.SetPosition(0, entry.position);
            
            
            for (int i = 0; i < nodes.Count; i++)
            {
                lineRenderer.SetPosition(i + 1, nodes[i].position);
            }

            lineRenderer.SetPosition(nodes.Count + 1, end.position);
            
        }
        else
        {
            lineRenderer.SetPosition(1, end.position);
        }
        lineRenderer.rendererPriority = 1;
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (nodes.Count != 0) 
        {
            Gizmos.DrawLine(entry.position, nodes[0].position);

            if (nodes.Count != 1)
            {
                for (int i = 0; i < nodes.Count - 1; i++)
                {
                    Gizmos.DrawLine(nodes[i].position, nodes[i + 1].position);
                }
            }

            Gizmos.DrawLine(nodes[nodes.Count - 1].position, end.position);
        }
        else
        {
            Gizmos.DrawLine(entry.position, end.position);
        }
    }

#endif
}
