using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderFlipper : MonoBehaviour
{
    [SerializeField] private Transform Render;
    private WalkControll walkControll;

    private Vector3 ScaleVector = Vector3.zero;

    private void Start()
    {
        walkControll = GetComponent<WalkControll>();
    }

    private void Update()
    {
        if (walkControll.rawDirection != 0)
        {
            float SignOfDirection = walkControll.rawDirection / Mathf.Abs(walkControll.rawDirection);
            float SignOfScaleXOfRender = Render.localScale.x / Mathf.Abs(Render.localScale.x);

            if (SignOfDirection != SignOfScaleXOfRender)
            {
                ScaleVector.y = Render.localScale.y;
                ScaleVector.x = Render.localScale.x * -1;
                Render.localScale = ScaleVector;
            }
        }
    }
}
