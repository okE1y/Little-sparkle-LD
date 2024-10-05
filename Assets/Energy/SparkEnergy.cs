using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkEnergy : MonoBehaviour
{
    private PlayerEnergy playerEnergy;
    private Rigidbody2D parentRigidbody2D;
    private GameObject parentObject;
    private Collider2D parenCollider;
    private Collider2D _collider;
    private SparkBehaviour SparkBehaviour;
    [SerializeField] private GameObject RenderedObject;

    private void Start()
    {
        parentRigidbody2D = GetComponentInParent<Rigidbody2D>();
        parentObject = parentRigidbody2D.gameObject;
        SparkBehaviour = parentObject.GetComponent<SparkBehaviour>();
        parenCollider = parentObject.GetComponent<Collider2D>();
        _collider = GetComponent<Collider2D>();
        playerEnergy = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEnergy>();
    }

    public void DisableEnergy()
    {
        _collider.enabled = false;
        RenderedObject.SetActive(false);
    }

    public void EnableEnergy()
    {
        _collider.enabled = true;
        RenderedObject.SetActive(true);
    }

    public void ResetEnergy()
    {
        _collider.enabled = true;
        RenderedObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerEnergy.AddEnergy(1);
            SparkBehaviour.StopSpark();
            parentRigidbody2D.Sleep();
            _collider.enabled = false;
            RenderedObject.SetActive(false);
        }
    }
}
