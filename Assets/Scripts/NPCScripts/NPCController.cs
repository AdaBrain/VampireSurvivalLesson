using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdaBrain.Core;

namespace AdaBrain.NPC
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private float breakDistance = 2.0f;
        [SerializeField] private float damage = 1.0f;
        [SerializeField] private float cooldown = 1.0f;

        private Rigidbody2D rb2d;
        private GameObject player;
        private Vector3 prvPosition;
        private Vector3 curPosition;
        private SpriteRenderer sr;
        private float lastTimeAttack = 0.0f;
        

        // Start is called before the first frame update
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            player = GameObject.FindGameObjectWithTag("Player");
            curPosition = transform.position;
            prvPosition = curPosition;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            ChasePlayer();            
        }

        private void FlipNPC()
        {
            float deltaX = prvPosition.x - curPosition.x;
            print(deltaX);
            sr.flipX = deltaX < 0;
        }
 
        private void ChasePlayer()
        {
            // Break chasing 
            float betweenDistance = Vector2.Distance(transform.position, player.transform.position);            
            if (breakDistance >= betweenDistance)
            {
                Attack();
                return;
            }

            // Save Previous Position States
            prvPosition = rb2d.position;

            Vector2 playerPosition = (Vector2) player.transform.position;
            float deltaS = speed * Time.fixedDeltaTime;

            // Save Current Position States
            curPosition = Vector2.MoveTowards(rb2d.position, playerPosition, deltaS);

            // Move to current position
            rb2d.position = curPosition;            
            
            FlipNPC();
        }

        private void Attack()
        {
            if (Time.time > lastTimeAttack + cooldown)
            {
                lastTimeAttack = Time.time;
                Health playerHealth = player.GetComponent<Health>();
                playerHealth.TakeDamage(damage);
            }

        }
    }
}

