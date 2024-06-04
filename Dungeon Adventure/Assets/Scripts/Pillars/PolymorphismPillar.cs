using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolymorphismPillar : MonoBehaviour, ICollectable {
    [SerializeField]
    private int pillar = 1;
    private static event Action OnPillarCollected;
    public void Collect() {
        Debug.Log("Polymorphism Pillar Collected");
        GameManager.AddPillars(pillar);
        Destroy(gameObject);
        OnPillarCollected?.Invoke();    // ? checks if it is not null
    }
}
