using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireEntry : MonoBehaviour, IInteractionObject
{
    private Transform _transfrom;
    private WireController wireController;
    private Wire wire;

    public Transform GetTransform { get
    {
        if (_transfrom == null) _transfrom = transform;
        return _transfrom;
    } }

    private void Start()
    {
        wire = GetComponentInParent<Wire>();
        wireController = GameObject.FindGameObjectWithTag("Player").GetComponent<WireController>();
    }

    public void Interaction()
    {
        wireController.ActivateWire(wire, this);
    }
}
