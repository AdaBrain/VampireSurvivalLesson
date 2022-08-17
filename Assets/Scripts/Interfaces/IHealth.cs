using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHealth
{
    // Properties
    public float Health { get; set; }
    public float MaxHealth { get; set; }
    public bool IsDie { get; set; }

    // Methods
    public void TakeDamage(float damage);
    public void RecoveryHP(float hpValue);
    public void Die();

}
