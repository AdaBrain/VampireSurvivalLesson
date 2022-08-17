using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    // Fields
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private bool isDie = false;
    [SerializeField] private RectTransform HPBar;

    // Properties
    public float Health {
        get => health;
        set {            
            if (value >= maxHealth) health = maxHealth;
            if (value < 0) health = 0;

            health = value;
        }
    }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public bool IsDie { get => isDie; set => isDie = value; }
    

    // Methods
    void Update()
    {
        SetHPBar();
    }

    private void SetHPBar()
    {
        float deltaX = (Health / MaxHealth) - 1;
        if (deltaX > 0) return;

        Vector3 curPos = HPBar.localPosition;
        HPBar.localPosition = new Vector3(deltaX, curPos.y, curPos.z);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;       
    }

    public void RecoveryHP(float hpValue)
    {
        Health += hpValue;
    }

    public void Die()
    {
        isDie = true;

        // should add set dieAnimation HERE
    }
}
