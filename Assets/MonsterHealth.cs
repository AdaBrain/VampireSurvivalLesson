using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdaBrain.Core;
using AdaBrain.Managers;

public class MonsterHealth : Health
{
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
}
