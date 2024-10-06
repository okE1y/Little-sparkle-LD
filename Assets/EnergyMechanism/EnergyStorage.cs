using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyStorage : MonoBehaviour, IInteractionObject, RoomControllable
{
    private PlayerEnergy playerEnergy;
    private Transform _transform;

    [SerializeField] private bool storageActive = true;

    public bool StorageActive { get => storageActive; }

    [SerializeField] private int MaxEnergy = 1;

    [SerializeField] private int currentEnergy;
    public int CurrentEnergy { get => currentEnergy; }

    private bool eventAssigned = false;

    private bool MechanismActivated = false;
    public UnityEvent ActivateMechanism = new UnityEvent();
    public UnityEvent DisableMechanism = new UnityEvent();

    public void SetStorageActive(bool active)
    {
        storageActive = active;
    }

    public Transform GetTransform
    {
        get
        {
            if (_transform == null) _transform = transform;
            return _transform;
        }
    }

    private void Start()
    {
        playerEnergy = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEnergy>();
        
    }

    private bool CheckStorageKeepOrGive() // если true то отдать энергию, если false то забрать у игрока
    {
        bool Give = false;

        if (currentEnergy >= MaxEnergy)
            Give = true;
        else if (playerEnergy.EnergyCount == 0)
            Give = true;

        return Give;
        
    }

    public void ReturnEnergy()
    {
        playerEnergy.AddEnergy(currentEnergy);
        currentEnergy = 0;

        if (eventAssigned)
        {
            playerEnergy.ReturnEnergy.RemoveListener(ReturnEnergy);

            eventAssigned = false;
        }
    }

    private void ChangeMechanismStatus()
    {
        if (currentEnergy == MaxEnergy && !MechanismActivated)
        {
            MechanismActivated = true;
            ActivateMechanism.Invoke();
        }
        else if (currentEnergy != MaxEnergy && MechanismActivated)
        {
            MechanismActivated = false;
            DisableMechanism.Invoke();
        }
    }

    public void Interaction()
    {
        if (storageActive)
        {
            if (CheckStorageKeepOrGive())
            {
                playerEnergy.AddEnergy(currentEnergy);
                currentEnergy = 0;

                if (eventAssigned)
                {
                    playerEnergy.ReturnEnergy.RemoveListener(ReturnEnergy);

                    eventAssigned = false;
                }
            }
            else
            {
                currentEnergy += playerEnergy.GetEnergy(MaxEnergy - currentEnergy);

                if (!eventAssigned)
                {
                    playerEnergy.ReturnEnergy.AddListener(ReturnEnergy);

                    eventAssigned = true;
                }
            }

            ChangeMechanismStatus();
        }
    }

    public void Disable()
    {
        playerEnergy.ReturnEnergy.RemoveListener(ReturnEnergy);
    }

    public void Enable()
    {
        if (eventAssigned)
        {
            playerEnergy.ReturnEnergy.AddListener(ReturnEnergy);
        }
    }

    public void ResetEntity()
    {
        if (eventAssigned)
        {
            eventAssigned = false;
            playerEnergy.ReturnEnergy.RemoveListener(ReturnEnergy);
        }

        currentEnergy = 0;

        if (MechanismActivated)
        {
            DisableMechanism.Invoke();
            MechanismActivated = false;
        }
    }
}
