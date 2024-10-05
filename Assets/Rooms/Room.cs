using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room : MonoBehaviour
{
    public Vector2 CameraMinPoint;
    public Vector2 CameraMaxPoint;

    private Transform _transform;

    public Transform GetTransform { get
    {
        if (_transform == null) _transform = transform;
        return _transform;
    } }

    public Vector2 Pos { get => GetTransform.position; }

    public Vector2 GetMinInWorld() => CameraMinPoint + Pos;
    public Vector2 GetMaxInWorld() => CameraMaxPoint + Pos;
}
