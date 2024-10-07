using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    private PlayerEnergy playerEnergy;
    private Transform _transform;

    private void Start()
    {
        playerEnergy = GetComponent<PlayerEnergy>();
        _transform = transform;
    }

    public void ResetPlayer(Room currentRoom)
    {
        playerEnergy.RemoveEnergy();
        _transform.position = currentRoom.StartPointOfLevel.position;
    }
}
