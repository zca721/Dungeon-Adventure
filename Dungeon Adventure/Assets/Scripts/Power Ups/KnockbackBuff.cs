using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Power Ups/Knockback Buff")]
public class KnockbackBuff : PowerUpEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<BarbarianAttacks>().knockbackForce += amount;
    }
}
