using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonHook : MonoBehaviour, IUIButton
{
    [SerializeField] private UnityEvent Action = new UnityEvent();

    [SerializeField] private Animator buttonAnimator;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip Selected;
    [SerializeField] private AudioClip Pushed;

    public void InvokeAction()
    {
        audioSource.clip = Pushed;
        audioSource.Play();
        Action.Invoke();
    }

    public void SetSelected(bool selected)
    {
        if (selected)
        {
            audioSource.clip = Selected;
            audioSource.Play();
        }

        buttonAnimator.SetBool("Selected", selected);
    }
}
