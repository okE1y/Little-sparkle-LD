using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyText : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] private EnergyStorage energyStorage;

    private float MaxEnergy;

    private void Start()
    {
        MaxEnergy = energyStorage.MaxEnergy;
    }

    private void Update()
    {
        textMesh.SetText(energyStorage.CurrentEnergy + "/" + MaxEnergy);
    }
}
