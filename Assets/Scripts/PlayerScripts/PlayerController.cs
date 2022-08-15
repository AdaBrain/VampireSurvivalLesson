using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator anim;

    public Animator Anim { get => anim; set => anim = value; }
    public SpriteRenderer Sr { get => sr; set => sr = value; }
    public Rigidbody2D Rb2d { get => rb2d; set => rb2d = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movements();
    }

    private void Movements()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (hAxis != 0 || vAxis != 0)
        {
            Vector2 movement = new Vector2(hAxis, vAxis);
            movement = rb2d.position + movement * speed * Time.fixedDeltaTime;

            FlipSR(hAxis);
            anim.SetBool("IsWalking", true);
            rb2d.MovePosition(movement);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }

    private void FlipSR(float hAxis)
    {
        sr.flipX = hAxis < 0;
    }
}
