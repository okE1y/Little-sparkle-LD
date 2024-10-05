using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEnergy : MonoBehaviour
{
    public Event ReturnEnergy = new Event();

    [SerializeField] private int _energyCount;
    public int EnergyCount { get => _energyCount; }

    public void AddEnergy(int energy) => _energyCount += energy;

    public void RemoveEnergy() => _energyCount = 0;

    public void GetBackEnergy(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ReturnEnergy.Use();
        }
    }

    public int GetEnergy(int Count)
    {
        _energyCount -= Count;
        if (_energyCount < 0)
        {
            Count += _energyCount;
            _energyCount = 0;
        }

        return Count;
    }



}
