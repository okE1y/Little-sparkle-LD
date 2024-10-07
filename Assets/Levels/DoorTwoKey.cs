using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorTwoKey : MonoBehaviour
{
    public int Sinals = 0;
    public int MaxSinals = 2;

    public UnityEvent Activating = new UnityEvent();

    public UnityEvent Disabling = new UnityEvent();

    public void AddSinal()
    {
        Sinals++;
        UpdateDoorState();
    }

    public void RemoveSinal()
    {
        Sinals--;
        UpdateDoorState();
    }

    private void UpdateDoorState()
    {
        if (Sinals == MaxSinals)
        {
            Activating.Invoke();
        }
        else
        {
            Disabling.Invoke();
        }
    }
}
