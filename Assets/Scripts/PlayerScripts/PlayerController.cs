using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float speed = 5.0f;
	[SerializeField] float cooldown = 1.0f;
	[SerializeField] GameObject SkillPrefab;

	private Rigidbody2D rb2d;
	private SpriteRenderer sr;
	private Animator anim;

	// Start is called before the first frame update
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		StartCoroutine(AutoSkill());

	}

	void Awake()
	{
		GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
		if (playerObjects.Length > 1) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Movements();
	}

	private IEnumerator AutoSkill()
	{
		while (true) {
			yield return new WaitForSeconds(cooldown);
			anim.SetTrigger("IsSpecial");
			UseSkill();
		}
	}

	private void UseSkill()
	{
		GameObject cloneSkill = Instantiate(SkillPrefab, transform.position, Quaternion.identity);
		ISkill skill = cloneSkill.GetComponent<PassiveSkill>();

		StartCoroutine(UpdateSkillPosition(cloneSkill));
		Destroy(cloneSkill, skill.Cooldown);
	}

	private IEnumerator UpdateSkillPosition(GameObject skillClone)
	{
		while (skillClone is not null) {
			Vector3 playerPosition = transform.position;
			try {
				skillClone.transform.position = playerPosition;
			} catch {
				break;
			}
			yield return new WaitForSeconds(0.01f);
		}
	}

	private void Movements()
	{
		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");

		if (hAxis != 0 || vAxis != 0) {
			Vector2 moveVector = new Vector2(hAxis, vAxis);

			moveVector = rb2d.position + moveVector * speed * Time.fixedDeltaTime;
			rb2d.MovePosition(moveVector);

			FlipSR(hAxis);
			AnimationWalk(true);
		} else {
			AnimationWalk(false);
		}
	}

	private void AnimationWalk(bool isWalk)
	{
		anim.SetBool("IsWalk", isWalk);
	}

	private void FlipSR(float hAxis)
	{
		sr.flipX = hAxis < 0;
	}
}
