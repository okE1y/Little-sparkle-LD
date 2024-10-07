using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonHook : MonoBehaviour, IUIButton
{
    [SerializeField] private UnityEvent Action = new UnityEvent();

    [SerializeField] private Animator buttonAnimator;

    public void InvokeAction()
    {
        Action.Invoke();
    }

    public void SetSelected(bool selected)
    {
        buttonAnimator.SetBool("Selected", selected);
    }
}
