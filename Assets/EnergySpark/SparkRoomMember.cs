using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkRoomMember : MonoBehaviour, RoomControllable
{
    private SparkBehaviour sparkBehaviour;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        sparkBehaviour = GetComponent<SparkBehaviour>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Disable()
    {
        sparkBehaviour.StopSpark();
        sparkBehaviour.enabled = false;
        _rigidbody2D.Sleep();
    }

    public void Enable()
    {
        _rigidbody2D.WakeUp();
        sparkBehaviour.enabled = true;
        sparkBehaviour.StartSpark();
    }

    public void ResetEntity()
    {
        sparkBehaviour.ResetSpark();
    }
}
