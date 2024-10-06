using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Wire wire;

    private void Start()
    {
        wire = GetComponent<Wire>();
    }

    public void ActivateWire()
    {
        wire.SetWireActive(true);
    }

    public void DisableWire()
    {
        wire.SetWireActive(false);
    }
}
