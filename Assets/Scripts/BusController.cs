using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BusController : MonoBehaviour
{
    [SerializeField] private float checkoutSeconds = 2f;
    [SerializeField] private CameraFollow cameraFollow;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Player")
        {
            PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();
            playerMovement.enabled = false;
            cameraFollow.enabled = false;

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            audioSource.Play();
            StartCoroutine(FinishLevel());
        }
    }

    private IEnumerator FinishLevel()
    {
        Debug.Log("is called gere");
        yield return new WaitForSeconds(checkoutSeconds);

        Debug.Log("check here");
        SceneManager.LoadScene(2);
    }
}
