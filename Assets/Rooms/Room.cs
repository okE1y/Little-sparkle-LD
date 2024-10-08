using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room : MonoBehaviour
{
    public Vector2 CameraMinPoint;
    public Vector2 CameraMaxPoint;

    private Transform _transform;

    private List<RoomControllable> Entities = new List<RoomControllable>();

    public Transform StartPointOfLevel;

    public Transform GetTransform { get
    {
        if (_transform == null) _transform = transform;
        return _transform;
    } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RoomControllable roomControllable;
        if (collision.TryGetComponent<RoomControllable>(out roomControllable))
        {
            Entities.Add(roomControllable);
        }
    }

    private void Start()
    {
        StartCoroutine(WaitOneFrames());
    }

    public void DisableRoom()
    {
        foreach (var i in Entities)
        {
            i.Disable();
        }
    }

    public void ResetRoom()
    {
        foreach (var i in Entities)
        {
            i.ResetEntity();
        }
    }

    public void EnableRoom()
    {
        foreach (var i in Entities)
        {
            i.Enable();
        }
    }

    private IEnumerator WaitOneFrames()
    {
        yield return null;
        yield return null;
        GetComponent<Collider2D>().enabled = false;
        yield break;
    }

    public Vector2 Pos { get => GetTransform.position; }

    public Vector2 GetMinInWorld() => CameraMinPoint + Pos;
    public Vector2 GetMaxInWorld() => CameraMaxPoint + Pos;
}

public interface RoomControllable
{
    public void Disable();
    public void Enable();
    public void ResetEntity();
}
