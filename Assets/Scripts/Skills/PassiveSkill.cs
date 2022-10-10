using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdaBrain.Core;

public class PassiveSkill : MonoBehaviour, ISkill
{
	[SerializeField] float damage = 1.0f;
	[SerializeField] float cooldown = 1.0f;

	public float Cooldown { get => cooldown; set => cooldown = value; }

	public void TakeDamage(GameObject enemy)
	{
		Health enemyHealth = enemy.GetComponent<Health>();
		enemyHealth.TakeDamage(damage);
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy")) {
			TakeDamage(collision.gameObject);
		}
	}
}
