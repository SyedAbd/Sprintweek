using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationCon : MonoBehaviour
{

    Animator animator;
    //[SerializeField] private LayerMask jumpableGround;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") )
        {
            animator.SetTrigger("IsNotGrounded");
            //jumpSoundEffect.Play();
        }
    }
   
}
