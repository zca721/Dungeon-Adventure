using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolymorphismPillar : MonoBehaviour, ICollectable
{
    public static event Action OnPillarCollected;
    public void Collect()
    {
        Debug.Log("Polymorphism Pillar Collected");
        Destroy(gameObject);
        OnPillarCollected?.Invoke();    // ? checks if it is not null
    }
}
