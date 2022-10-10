using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
	public void TakeDamage(GameObject enemy);
	public float Cooldown {
		get;
		set;
	}
}
