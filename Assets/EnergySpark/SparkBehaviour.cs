using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator animator;

    [SerializeField] private float SparkSpeed;
    [SerializeField] private float MaxPause;
    [SerializeField] private float MinPause;
    [SerializeField] private float MaxWalkingTime;
    [SerializeField] private float MinWalkingTime;

    public bool BehaviourEnabled { get; private set; }

    private bool Walking = false;
    private float direction = 1;

    public float Direction { get => direction; }

    private Vector3 speedVector = Vector3.zero;

    private Vector3 DefaultPos;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        DefaultPos = transform.position;
        StartSpark();
    }

    public void StartSpark()
    {
        if (!BehaviourEnabled)
        {
            BehaviourEnabled = true;
            StartCoroutine(Behaviour());
        }
    }

    public void StopSpark()
    {
        StopAllCoroutines();
        Walking = false;
        BehaviourEnabled = false;
    }

    public void ResetSpark()
    {
        StopSpark();
        transform.position = DefaultPos;
        StartSpark();
    }

    private IEnumerator Behaviour()
    {
        while (true)
        {
            animator.SetBool("Walk", Walking);
            yield return new WaitForSeconds(Random.Range(MinPause, MaxPause));

            //randomize 1 -1
            if (Random.Range(-1f, 1f) > 0) direction = -1;
            else direction = 1;

            Walking = true;

            animator.SetBool("Walk", Walking);

            yield return new WaitForSeconds(Random.Range(MinWalkingTime, MaxWalkingTime));

            Walking = false;
            _rigidbody2D.velocity = Vector2.zero;

        }
    }

    private void Update()
    {

        if (Walking)
        {
            speedVector.x = direction * SparkSpeed;
            speedVector.y = _rigidbody2D.velocity.y;

            _rigidbody2D.velocity = speedVector;
        }
    }
}
