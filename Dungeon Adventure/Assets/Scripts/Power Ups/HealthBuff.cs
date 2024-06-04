using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Power Ups/Health Buff")]
public class HealthBuff : PowerUpEffect {
    public float amount;

    public override void Apply(GameObject target) {
        target.GetComponent<DamageableCharacter>().Health += amount;
    }
}
