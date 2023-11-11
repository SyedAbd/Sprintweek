using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private CapsuleCollider2D collide;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private string playerState = "run";
    //private Animator animator;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;

    private float directionX = 1f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collide = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
           rigidBody.velocity = new Vector2(newPosition, velocityY);
        }
        if (playerState == "clim")
        {
            rigidBody.velocity = new Vector2(0, 4);
        }

        if ((Input.GetButtonDown("Jump") || playerState=="jump") && IsGrounded())
        {
            rigidBody.velocity = new Vector2(velocityX, jumpForce);
            //jumpSoundEffect.Play();
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag + " : " + gameObject.tag + " : " + Time.time);
        if (col.gameObject.tag == "Clim")
        {
            playerState = "clim";
        }
        else if (col.gameObject.tag == "Jump")
        {
            playerState = "jump";
        }
       //spriteMove = -0.1f;
    }
    void OnTriggerExit2D(Collider2D col2)
    {
        playerState = "run";
    }
    private bool IsGrounded()
    {
        Bounds bounds = collide.bounds;
        return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
