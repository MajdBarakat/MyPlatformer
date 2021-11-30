using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D collider;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f  ;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 15f;

    [SerializeField] private AudioSource walkSE;
    [SerializeField] private AudioSource jumpSE;
    

    private enum MovementState {idle, running, jumping, falling, none };

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per framed
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(dirX * moveSpeed, rigidBody.velocity.y);


        if (Input.GetButtonDown("Jump") && UpdateGroundedState())
        {
            jumpSE.Play();
            rigidBody.velocity = new Vector2(0, jumpForce);
        }

        UpdateAnmimationState();
    }

    private void UpdateAnmimationState()
    {
        MovementState state;

        if (dirX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
            if (walkSE.isPlaying == false && UpdateGroundedState())
            {
                walkSE.Play();
            }
        }
        else if (dirX < 0)
        {

            state = MovementState.running;
            sprite.flipX = true;
            if(walkSE.isPlaying == false && UpdateGroundedState())
            {
            walkSE.Play();
            }
        }
        else
        {
            state = MovementState.idle;
        }

        if (rigidBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rigidBody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }


        animator.SetInteger("state", (int)state);
      
    }

    private bool UpdateGroundedState()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround );
    }
}
