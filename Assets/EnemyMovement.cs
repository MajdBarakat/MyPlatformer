using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer sprite;

    private enum MovementState { idle, walking};

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementState state;

        if (rigidBody.velocity.x > .1f || rigidBody.velocity.x < .1f)
        {
            state = MovementState.walking;
        }
        else
        {
            state = MovementState.idle;
        }

        animator.SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftWP"))
        {          
            sprite.flipX = false;
        }
        else if (collision.gameObject.CompareTag("RightWP"))
        {
            sprite.flipX = true;
        }
    }
}
