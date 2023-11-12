using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private CapsuleCollider2D collide;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private string playerState = "run";
    Animator animator;
   
    //private Animator animator;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;

    private float directionX = 1f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 6f;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collide = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float velocityY = rigidBody.velocity.y;
        float velocityX = rigidBody.velocity.x;

        float newPosition = directionX * moveSpeed;
        if(playerState == "run")
        {
            if (IsGrounded())
            {
                rigidBody.velocity = new Vector2(newPosition, velocityY);
            }
           
        }
        if (playerState == "clim")
        {
            animator.SetBool("IsCliming", true);
            rigidBody.velocity = new Vector2(0, 2);
            

        }
        //if(playerState == "afterclim"|| playerState == "aafterclim")
        //{

        //    rigidBody.velocity = new Vector2(0, 6);
        //   // playerState = "aafterclim";
        //}

        if ((Input.GetButtonDown("Jump") || playerState=="jump") && IsGrounded())
        {
            rigidBody.velocity = new Vector2(0, jumpForce);
            animator.SetTrigger("IsNotGrounded");
            //jumpSoundEffect.Play();
        }

        if (IsGrounded())
        {
            animator.SetTrigger("IsGrounded");
        }
        else
        {
            animator.SetTrigger("IsNotGrounded");
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag + " : " + gameObject.tag + " : " + Time.time);
        if (col.gameObject.tag == "Clim")
        {
            playerState = "clim";
            animator.SetBool("IsCliming", true);
        }
        if (col.gameObject.tag == "Afterclim")
        {
            playerState = "afterclim";
            //animator.SetBool("IsCliming", true);
           // animator.play("Player_ClimbUp")
        }
        else if (col.gameObject.tag == "Jump")
        {
            playerState = "jump";
        }
       //spriteMove = -0.1f;
    }
    void OnTriggerExit2D(Collider2D col2)
    {
        if(playerState == "clim")
        {
            animator.SetBool("IsCliming",false);
            playerState = "run";
        }
        //if(playerState== "aafterclim")
        //{
        //    playerState = "run";

        //}


    }
    private bool IsGrounded()
    {
        Bounds bounds = collide.bounds;
        return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
