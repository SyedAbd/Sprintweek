using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private SceneController sceneController;

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

    private void InitDeathScreen()
    {
        sceneController.ChangeScene(1);
    }
}
