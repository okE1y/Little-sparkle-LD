using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTranslator : MonoBehaviour
{
    [SerializeField] private Transform TeleportToPoint;
    [SerializeField] private Room RoomFrom;
    [SerializeField] private Room RoomTo;
    private RoomManager roomManager;
    private Transform PlayerTransform;

    private void Start()
    {
        roomManager = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerTransform.position = TeleportToPoint.position;
            roomManager.TransferPlayer(RoomFrom, RoomTo);
        }
    }
}
