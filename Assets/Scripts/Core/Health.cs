using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdaBrain.Core
{
	public abstract class Health : MonoBehaviour
	{
		// Fields
		[SerializeField] private float maxHP;
		[SerializeField] private float curHP;
		[SerializeField] GameObject hpMask;
		[SerializeField] GameObject DeadEffectPrefab;

		private RectTransform hpMaskTransform;

		public float MaxHP { get => maxHP; set => maxHP = value; }
		public float CurHP {
			get => curHP;
			set {
				if (value < 0) curHP = 0;
				else if (value > maxHP) curHP = maxHP;
				else {
					curHP = value;
				}
			}
		}

		public RectTransform HpMaskTransform { get => hpMaskTransform; set => hpMaskTransform = value; }
		public GameObject HpMask { get => hpMask; set => hpMask = value; }

		public void UpdateHPBar()
		{
			// Max scale = 0, Min scale = -1
			float ratio = (curHP / maxHP) - 1;
			Vector3 newPosition = new Vector3(ratio, 0, 0);
			hpMaskTransform.localPosition = newPosition;
		}

		public virtual void TakeDamage(float damage)
		{
			CurHP -= damage;

			if (CurHP <= 0) {
				OnDead();
			}
		}

		public virtual void OnDead()
		{
			GameObject cloneDeadEffect = Instantiate(DeadEffectPrefab, transform.position, Quaternion.identity);
			Destroy(cloneDeadEffect, 1.0f);
			Destroy(gameObject);
		}
	}
}
