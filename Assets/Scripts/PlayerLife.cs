using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
      
        if (gameObject.tag.Equals("Die"))
        {
            animator.Play("Player_Die");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("MainCamera")) {
            animator.Play("Player_Die");
        }
    }

    private void InitDeathScreen()
    {
        SceneManager.LoadScene(2);
    }
}
