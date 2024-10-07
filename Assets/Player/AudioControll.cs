using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControll : MonoBehaviour
{
    public AudioSource audioSourceStep;
    public AudioSource audioSourceJump;
    public AudioSource audioSourcewire;
    public AudioSource audioSourceMechanism;

    public bool walkPlaing = false;

    public float Dalay;

    public void PlayJump()
    {
        audioSourceJump.Play();
    }

    public void PlayWire()
    {
        audioSourcewire.Play();
    }

    public void PlayeMechanism()
    {
        audioSourceMechanism.Play();
    }

    public void Stop()
    {
        StopAllCoroutines();
        walkPlaing = false;
    }

    public void PlayWalk()
    {
        if (!walkPlaing)
        {
            walkPlaing = true;

            StartCoroutine(PlayLoop());
        }
    }

    private IEnumerator PlayLoop()
    {
        while (true)
        {
            audioSourceStep.Play();
            yield return new WaitForSeconds(Dalay);
        }
    }    
}
