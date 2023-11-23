using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private CapsuleCollider2D collide;
    [SerializeField] private string playerState = "run";

    private Animator animator;
    private bool climAvailable = false;
    private bool climFlag = false;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;

    private float directionX = 1f;
    private float climbingForce = 2f;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 4f;

    private bool dontMove = false;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collide = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float velocityY = rigidBody.velocity.y;
        float velocityX = rigidBody.velocity.x;

        //Debug.Log("current velocity" + velocityY);


        if(Input.GetKeyDown(KeyCode.V)&& IsGrounded())
        {

            animator.Play("Player_Roll");


        }




        float newPosition = directionX * moveSpeed;
        if (playerState == "run")
            if (IsGrounded() && !dontMove)
            {
                rigidBody.velocity = new Vector2(newPosition, velocityY);
            }
        

        if (playerState == "clim")
        {
            if (climFlag)
            {
                rigidBody.velocity = new Vector2(0, climbingForce);

            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                climFlag = true;
                animator.SetBool("IsCliming", true);
                rigidBody.velocity = new Vector2(0, climbingForce);
            }
            //else playerState = "run";
        }



        if ((Input.GetButtonDown("Jump") || playerState == "jump") && IsGrounded())
        {
            rigidBody.velocity = new Vector2(velocityX, jumpForce);

            animator.SetTrigger("Jump");
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

        //if (velocityY < -.1f && playerState == "jump")
        //    animator.SetBool("IsFalling", true);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Clim")
        {
            //climAvailable = true;
            playerState = "clim";
            //animator.SetBool("IsCliming", true);
        }

        else if (col.gameObject.tag == "DontMove")
        {
            dontMove = true;
        }
        
        else if (col.gameObject.tag == "Jump")
        {
            playerState = "jump";
        }
        //else if (col.gameObject.tag == "Die")
        //{
        //    animator.Play("Player_Die");

        //    // Put your code here for dying scene load


        //}
        //spriteMove = -0.1f;
    }
    private void OnTriggerExit2D(Collider2D col2)

    {
        if(playerState == "clim" && climFlag == false && col2.gameObject.tag == "Clim") playerState = "run";
        if (playerState == "clim" && col2.gameObject.tag == "Clim")
        {
            
            animator.SetBool("IsCliming", false);
            animator.SetBool("IsAfterClimb", true);
            climbingForce = 1.8f;
            

        }
        if (col2.gameObject.tag == "DontMove")
        {
            dontMove = false;
        }
    }
    private bool IsGrounded()
    {
        Bounds bounds = collide.bounds;
        return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void ClimbUp()
    {
        playerState = "run";
        rigidBody.velocity = new Vector2(1, 1);
        animator.SetBool("IsAfterClimb", false);
        climFlag = false;
        climbingForce = 2f;
    }
}
