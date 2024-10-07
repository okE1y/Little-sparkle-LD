using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerEnergy : MonoBehaviour
{
    public UnityEvent ReturnEnergy = new UnityEvent();

    [SerializeField] private AudioControll audioControll;

    [SerializeField] private int _energyCount;
    public int EnergyCount { get => _energyCount; }

    public bool EnergyGetBackAcive = true;

    public void AddEnergy(int energy) => _energyCount += energy;

    public void RemoveEnergy() => _energyCount = 0;

    public void GetBackEnergy(InputAction.CallbackContext context)
    {
        if (EnergyGetBackAcive && context.started)
        {
            ReturnEnergy.Invoke();
            audioControll.PlayeMechanism();
        }
    }

    public int GetEnergy(int Count)
    {
        if(_energyCount != 0 || Count != 0)
            audioControll.PlayeMechanism();

        _energyCount -= Count;
        if (_energyCount < 0)
        {
            Count += _energyCount;
            _energyCount = 0;
        }



        return Count;
    }



}
