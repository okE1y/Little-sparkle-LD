using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireController : MonoBehaviour
{
    private PlayerInteract playerInteract;
    private WalkControll walkControll;
    private JumpControll jumpControll;
    private PlayerEnergy playerEnergy;
    private Rigidbody2D _rigidbody2D;
    private Transform GetTransform;

    [SerializeField] private AudioControll audioControll;

    [SerializeField] private float wireSpeed;

    private Wire currentWire;

    [SerializeField] private Animator animator;

    private void Start()
    {
        playerInteract = GetComponent<PlayerInteract>();
        walkControll = GetComponent<WalkControll>();
        jumpControll = GetComponent<JumpControll>();
        playerEnergy = GetComponent<PlayerEnergy>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        GetTransform = transform;
    }

    public void ActivateWire(Wire activatingWire, WireEntry entry)
    {
        if (activatingWire.WireActive && playerEnergy.EnergyCount != 0)
        {
            audioControll.PlayWire();
            currentWire = activatingWire;

            playerInteract.ActiveInteraction = false;
            walkControll.WalkActive = false;
            jumpControll.JumpActive = false;
            playerEnergy.EnergyGetBackAcive = false;
            _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

            transform.position = entry.GetTransform.position;

            animator.SetTrigger("BeginWire");

            StartCoroutine(TransferPlayerByWire(entry.GetTransform.position == currentWire.entry.position));
        }
    }

    private IEnumerator TransferPlayerByWire(bool FromEntryOrEnd)
    {
        if (FromEntryOrEnd)
        {
            for (int i = 0; i < currentWire.nodes.Count; i++)
            {
                
                while (GetTransform.position != currentWire.nodes[i].position)
                {
                    GetTransform.position = Vector3.Lerp(GetTransform.position, currentWire.nodes[i].position, Time.deltaTime * wireSpeed /
                        Vector3.Distance(GetTransform.position, currentWire.nodes[i].position));

                    yield return null;
                }
            }

            while (GetTransform.position != currentWire.end.position)
            {
                GetTransform.position = Vector3.Lerp(GetTransform.position, currentWire.end.position, Time.deltaTime * wireSpeed /
                    Vector3.Distance(GetTransform.position, currentWire.end.position));

                yield return null;
            }
        }
        else
        {
            for (int i = currentWire.nodes.Count - 1; i > -1; i--)
            {

                while (GetTransform.position != currentWire.nodes[i].position)
                {
                    GetTransform.position = Vector3.Lerp(GetTransform.position, currentWire.nodes[i].position, Time.deltaTime * wireSpeed /
                        Vector3.Distance(GetTransform.position, currentWire.nodes[i].position));

                    yield return null;
                }
            }

            while (GetTransform.position != currentWire.entry.position)
            {
                GetTransform.position = Vector3.Lerp(GetTransform.position, currentWire.entry.position, Time.deltaTime * wireSpeed /
                    Vector3.Distance(GetTransform.position, currentWire.entry.position));

                yield return null;
            }
        }

        playerInteract.ActiveInteraction = true;
        walkControll.WalkActive = true;
        jumpControll.JumpActive = true;
        playerEnergy.EnergyGetBackAcive = true;
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

        animator.SetTrigger("EndWire");

        yield break;
    }
}
