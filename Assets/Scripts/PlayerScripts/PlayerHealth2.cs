using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdaBrain.Core;
using AdaBrain.Managers;

public class PlayerHealth2 : Health
{
	void Start()
	{
		HpMaskTransform = HpMask.GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update()
	{
		UpdateHPBar();
	}
}
