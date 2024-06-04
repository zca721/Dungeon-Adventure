using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Power Ups/Attack Buff")]
public class AttackBuff : PowerUpEffect {
    public float amount;

    public override void Apply(GameObject target) {
        target.GetComponent<BarbarianAttacks>().punchDamage += amount;
    }
}
