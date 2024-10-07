using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyUI : MonoBehaviour
{
    [SerializeField] private GameObject energyAsset;

    private List<GameObject> InstantiatedEnergy = new List<GameObject>();

    private PlayerEnergy playerEnergy;

    [SerializeField] private Transform SpawnPoint;

    [SerializeField] private float padding;


    private void Start()
    {
        playerEnergy = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEnergy>();
    }

    private void SpawnEnergyAsset()
    {
        InstantiatedEnergy.Add(Instantiate(energyAsset, new Vector3(SpawnPoint.position.x - padding * InstantiatedEnergy.Count, SpawnPoint.position.y, SpawnPoint.position.z), Quaternion.identity, transform));
    }

    private void Update()
    {
        if (InstantiatedEnergy.Count < playerEnergy.EnergyCount)
        {
            int NeededEnergy = playerEnergy.EnergyCount - InstantiatedEnergy.Count;

            for (int i = 0; i < NeededEnergy; i++)
            {
                SpawnEnergyAsset();
            }
        }
        else if (InstantiatedEnergy.Count > playerEnergy.EnergyCount)
        {
            int DestroyCount = InstantiatedEnergy.Count - playerEnergy.EnergyCount;

            for (int i = InstantiatedEnergy.Count - 1; i > playerEnergy.EnergyCount - 1; i--)
            {
                Destroy(InstantiatedEnergy[i]);
                InstantiatedEnergy.RemoveAt(i);
            }
        }
    }
}
