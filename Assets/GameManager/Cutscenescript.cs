using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenescript : MonoBehaviour
{
    public Animator animator;

    public bool Walk;

    public bool Fall;

    public bool BeginWire;

    public bool EndWire;

    private void Update()
    {
        animator.SetBool("Walk", Walk);
        animator.SetBool("Fall", Fall);

        if (BeginWire)
            animator.SetTrigger("BeginWire");

        if (EndWire)
            animator.SetTrigger("EndWire");



        BeginWire = false;
        EndWire = false;
    }
}
