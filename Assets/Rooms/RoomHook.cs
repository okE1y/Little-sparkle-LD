using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomHook : MonoBehaviour, RoomControllable
{
    public UnityEvent DisableHook = new UnityEvent();
    public UnityEvent EnableHook = new UnityEvent();
    public UnityEvent ResetHook = new UnityEvent();

    public void Disable()
    {
        DisableHook.Invoke();
    }

    public void Enable()
    {
        EnableHook.Invoke();
    }

    public void ResetEntity()
    {
        ResetHook.Invoke();
    }
}
