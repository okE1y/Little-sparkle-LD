using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoBouncing : MonoBehaviour
{
    private float SinusInLastFrame;
    private Transform _transform;

    [SerializeField] private float Multiplier;

    private Vector3 sinusVector;

    private float time;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        time += Time.deltaTime;

        sinusVector.y = (Mathf.Sin(time) - SinusInLastFrame) * Multiplier;

        _transform.position += sinusVector;

        SinusInLastFrame = Mathf.Sin(time);
    }
}
