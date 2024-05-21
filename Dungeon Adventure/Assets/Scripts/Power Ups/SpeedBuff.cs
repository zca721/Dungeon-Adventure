using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Power Ups/Speed Buff")]
public class SpeedBuff : PowerUpEffect
{
    public float amount;

    public override void Apply(GameObject target) {
        target.GetComponent<PlayerController>().moveSpeed += amount;
    }
}
