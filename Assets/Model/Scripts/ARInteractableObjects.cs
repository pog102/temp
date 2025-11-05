using System.Collections.Generic;
using UnityEngine;

public abstract class ARIteractabbleObjects : MonoBehaviour
{
    private List<ARIteractabbleObjects> _interactables = new List<ARIteractabbleObjects>();

    protected enum State
    {
        Idle,
        Pushup,
    }

    protected State ARObjectState = State.Idle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ARIteractabbleObjects>(out var interactable))
        {
            AddInteractable(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ARIteractabbleObjects>(out var interactable))
        {
            RemoveInteractable(interactable);
        }
    }

    private void AddInteractable(ARIteractabbleObjects interactable)
    {
        _interactables.Add(interactable);
        SetState(State.Pushup);
    }

    private void RemoveInteractable(ARIteractabbleObjects interactable)
    {
        _interactables.Remove(interactable);
        if (_interactables.Count == 0)
        {
            SetState(State.Idle);
        }
    }

    private void OnDisable()
    {
        foreach (var interactable in _interactables)
        {
            interactable.RemoveInteractable(this);
        }
        _interactables.Clear();
        SetState(State.Idle);
    }

    protected virtual void SetState(State state)
    {
        ARObjectState = state;
    }
}
