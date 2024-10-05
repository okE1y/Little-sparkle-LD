using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkControll : MonoBehaviour
{
    public bool WalkActive { get; set; } = true;

    public float rawDirection { get; private set; }

    private float startDirection = 0f;

    private Rigidbody2D _rigidbody2D;
    [SerializeField] private ValueSmoother _valueSmoother;

    [SerializeField] private float Speed = 6f;
    [SerializeField] private float Inert = 10f;

    private Vector3 speedVector = Vector3.zero;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _valueSmoother = new ValueSmoother(Inert);
    }

    public void SetDirection(float Direction)
    {
        this.rawDirection = Direction;
        _valueSmoother.EndValue = this.rawDirection;
    }

    private void UpdateVelocity()
    {
        _valueSmoother.StartValue = startDirection;
        if (startDirection != rawDirection)
        {
            startDirection = _valueSmoother.GetValueByTime(Time.deltaTime);
        }

        speedVector = _rigidbody2D.velocity;
        speedVector.x = startDirection * Speed;

        _rigidbody2D.velocity = speedVector;
    }

    private void Update()
    {
        if (WalkActive)
        {
            UpdateVelocity();
        }
    }
}
