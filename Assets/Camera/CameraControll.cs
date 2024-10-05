using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Transform GetTransform;
    private Transform PlayerTransfrom;

    public bool CameraControlled = true;

    private Vector3 PlayerWorldPosWithCameraZ;

    private RoomManager roomManager;

    private Vector2 MinRoomPos;
    private Vector2 MaxRoomPos;

    private Vector2 CameraOfsets;

    private void Start()
    {
        GetTransform = transform;
        PlayerTransfrom = GameObject.FindGameObjectWithTag("Player").transform;
        roomManager = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
    }

    private void Update()
    {
        if (CameraControlled)
        {
            CameraOfsets = Camera.main.ViewportToWorldPoint(Vector2.one * 0.5f) - Camera.main.ViewportToWorldPoint(Vector3.zero);

            PlayerWorldPosWithCameraZ.x = PlayerTransfrom.position.x;
            PlayerWorldPosWithCameraZ.y = PlayerTransfrom.position.y;
            PlayerWorldPosWithCameraZ.z = GetTransform.position.z;

            MinRoomPos = roomManager[roomManager.CurrentRoom].GetMinInWorld() + CameraOfsets;
            MaxRoomPos = roomManager[roomManager.CurrentRoom].GetMaxInWorld() - CameraOfsets;

            

            PlayerWorldPosWithCameraZ.x = Mathf.Clamp(PlayerWorldPosWithCameraZ.x, MinRoomPos.x, MaxRoomPos.x);
            PlayerWorldPosWithCameraZ.y = Mathf.Clamp(PlayerWorldPosWithCameraZ.y, MinRoomPos.y, MaxRoomPos.y);

            GetTransform.position = PlayerWorldPosWithCameraZ;

            
        }
    }
}
