using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdaBrain.Core;
using AdaBrain.Managers;
using TMPro;

public class MonsterHealth : Health
{
	[SerializeField] float _damageTextDelay = 3.0f;
	[SerializeField] GameObject _damageTextPrefab;
	[SerializeField] float _forceFactor = 2.0f;
	[SerializeField] Vector2 _floatingPath = new(0, 1);
	private EnemyManager enemyManager;

	// Start is called before the first frame update
	void Start()
	{
		enemyManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnemyManager>();
		HpMaskTransform = HpMask.GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update()
	{
		UpdateHPBar();
	}

	public override void OnDead()
	{
		// Drop loot item
		int ItemSize = enemyManager.LootItems.Length;
		int randomItemIdx = Random.Range(0, ItemSize);
		GameObject[] lootItemList = enemyManager.LootItems;
		Instantiate(lootItemList[randomItemIdx], transform.position, Quaternion.identity);

		base.OnDead();
	}

	public override void TakeDamage(float damage)
	{
		base.TakeDamage(damage);

		// Show damage text
		GameObject damageTextClone = Instantiate(_damageTextPrefab, transform.position, Quaternion.identity);

		// Change text damage
		TextMeshPro floatingText = damageTextClone.GetComponent<TextMeshPro>();
		int actualDamage = (int)damage;
		if (actualDamage > 0)
		{
			floatingText.text = actualDamage.ToString();
		}
		else
		{
			floatingText.text = "MISS";
		}


		// Floating Text Effect
		Rigidbody2D rb2d = damageTextClone.GetComponent<Rigidbody2D>();
		rb2d.AddForce(_forceFactor * _floatingPath, ForceMode2D.Impulse);

		Destroy(damageTextClone, _damageTextDelay);
	}
}
