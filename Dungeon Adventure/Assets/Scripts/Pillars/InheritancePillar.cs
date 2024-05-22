using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritancePillar : MonoBehaviour, ICollectable
{
    
    [SerializeField]
    int pillar = 1;
    public static event Action OnPillarCollected;
    public void Collect()
    {
        Debug.Log("Inher Pillar Collected");
        GameManager.AddPillars(pillar);
        Destroy(gameObject);
        OnPillarCollected?.Invoke();    // ? checks if it is not null
    }
}
