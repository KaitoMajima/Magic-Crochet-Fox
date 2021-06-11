
using UnityEngine;
using System;

public class TriggeredInteraction : MonoBehaviour
{
    public Action Interact;
    public Action AreaEntered;
    public Action AreaExited;

    public void OnInteract()
    {
        Interact?.Invoke();
    }

    public void OnAreaEnter()
    {
        AreaEntered?.Invoke();
    }

    public void OnAreaExit()
    {
        AreaExited?.Invoke();
    }
}
