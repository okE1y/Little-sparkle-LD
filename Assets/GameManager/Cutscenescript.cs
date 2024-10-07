using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenescript : MonoBehaviour
{
    public Animator animator;

    public AudioSource audioSource;

    public bool Walk;

    public bool Fall;

    public bool BeginWire;

    public bool EndWire;

    public bool PlayAudio;

    private void Update()
    {
        animator.SetBool("Walk", Walk);
        animator.SetBool("Fall", Fall);

        if (BeginWire)
            animator.SetTrigger("BeginWire");

        if (EndWire)
            animator.SetTrigger("EndWire");


        if (PlayAudio)
            audioSource.Play();

        BeginWire = false;
        EndWire = false;
        PlayAudio = false;
    }
}
