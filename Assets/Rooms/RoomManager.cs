using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private List<Room> Rooms = new List<Room>();

    public Room this[int key] => Rooms[key];
    public int RoomCount { get => Rooms.Count; }

    [SerializeField] private int _currentRoom;
    public int CurrentRoom { get => _currentRoom; }

    public void TransferPlayer(Room from, Room to)
    {
        from.DisableRoom();
        to.EnableRoom();
        to.ResetRoom();

        _currentRoom = Rooms.FindIndex((x) => x.Equals(to));
    }

    private void Start()
    {
        StartCoroutine(WaitTwoFrames());
    }

    private IEnumerator WaitTwoFrames()
    {
        yield return null;
        yield return null;
        for (int i = 0; i < Rooms.Count; i++)
        {
            if (i != CurrentRoom)
            {
                Rooms[i].DisableRoom();
            }
        }
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        for (int i = 0; i < Rooms.Count; i++)
        {
            if (i == _currentRoom) Gizmos.color = Color.yellow;
            else Gizmos.color = Color.red;

            Gizmos.DrawLine(Rooms[i].GetMinInWorld(), new Vector2(Rooms[i].CameraMinPoint.x, Rooms[i].CameraMaxPoint.y) + Rooms[i].Pos);
            Gizmos.DrawLine(Rooms[i].GetMaxInWorld(), new Vector2(Rooms[i].CameraMinPoint.x, Rooms[i].CameraMaxPoint.y) + Rooms[i].Pos);
            Gizmos.DrawLine(Rooms[i].GetMinInWorld(), new Vector2(Rooms[i].CameraMaxPoint.x, Rooms[i].CameraMinPoint.y) + Rooms[i].Pos);
            Gizmos.DrawLine(Rooms[i].GetMaxInWorld(), new Vector2(Rooms[i].CameraMaxPoint.x, Rooms[i].CameraMinPoint.y) + Rooms[i].Pos);
        }
    }

#endif
}
