using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InteractableCollectible : MonoBehaviour
{
    [SerializeField] private TriggeredInteraction interaction;
    [SerializeField] private Collectible collectible;

    private void Start()
    {
        interaction.AreaEntered += OnCollect;
    }

    private void OnCollect()
    {
        interaction.AreaEntered -= OnCollect;
        collectible.OnCollect();
    }
}

[Serializable]
public class Collectible
{
    [SerializeField] private PlayableDirector timeline;

    public void OnCollect()
    {
        timeline.Play();
    }

}
