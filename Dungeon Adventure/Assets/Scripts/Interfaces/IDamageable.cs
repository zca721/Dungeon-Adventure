using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {  // Interface for all players and monsters
   private static float Health { set; get; }

   private static bool Targetable { set; get; }

    // Monsters that take knockback when hit
   public void OnHit(float damage, Vector2 knockback);

    // Monsters that do not take knockback when hit
   public void OnHit(float damage);

   public void DestroyDead();
}
