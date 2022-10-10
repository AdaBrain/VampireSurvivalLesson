using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RegularItem : MonoBehaviour, IItem
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) {
			SpecialEffect();
			Destroy(gameObject);
		}
	}

	public virtual void SpecialEffect()
	{
		return;
	}
}
