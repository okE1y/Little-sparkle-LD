using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private bool Opened;

    private void Start()
    {
        if (Opened)
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        animator.SetBool("Opened", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("Opened", false);
    }
}
