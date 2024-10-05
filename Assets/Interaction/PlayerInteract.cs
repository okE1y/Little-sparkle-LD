using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public void ActivateInteraction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InvokeNearesInteraction();
        }
    }

    private List<Interaction> interactions = new List<Interaction>();
    private Transform GetTransform;

    private void Start()
    {
        GetTransform = transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractionObject interactionObject;

        if (collision.TryGetComponent<IInteractionObject>(out interactionObject))
        {
            interactions.Add(new Interaction(interactionObject.Interaction, interactionObject.GetTransform));
        }
    }

    private void InvokeNearesInteraction()
    {
        if (interactions.Count != 0)
        {
            interactions.Sort((x, y) => Vector3.Distance(GetTransform.position, x.transformOfInteractionObj.position).CompareTo(Vector3.Distance(GetTransform.position, y.transformOfInteractionObj.position)));
            interactions[0].InvokeEvent();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (interactions.Count != 0)
        {
            IInteractionObject interactionObject;

            if (collision.TryGetComponent<IInteractionObject>(out interactionObject))
            {
                interactions.Remove(interactions.Find((x) => x.transformOfInteractionObj.Equals(interactionObject.GetTransform)));
            }
        }
    }
}

public class Interaction
{
    private UnityEvent unityEvent = new UnityEvent();
    public Transform transformOfInteractionObj { get; private set; }

    public Interaction(UnityAction function, Transform transform)
    {
        unityEvent.AddListener(function);
        transformOfInteractionObj = transform;
    }

    public void InvokeEvent()
    {
        unityEvent.Invoke();
    }

    ~Interaction()
    {
        unityEvent.RemoveAllListeners();
    }
}

public interface IInteractionObject
{
    public void Interaction();

    public Transform GetTransform { get; }
}
