using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkFlipper : MonoBehaviour
{
    [SerializeField] private Transform Render;
    private SparkBehaviour sparkBehaviour;

    private Vector2 ScaleVector;

    private void Start()
    {
        sparkBehaviour = GetComponent<SparkBehaviour>();
    }

    private void Update()
    {
        if (sparkBehaviour.BehaviourEnabled)
        {
            float SignOfDirection = sparkBehaviour.Direction / Mathf.Abs(sparkBehaviour.Direction);
            float SignOfScaleX = Render.localScale.x / Mathf.Abs(Render.localScale.x);

            if (SignOfDirection != SignOfScaleX)
            {
                ScaleVector.x = Render.localScale.x * -1;
                ScaleVector.y = Render.localScale.y;

                Render.localScale = ScaleVector;
            }
        }
    }
}
