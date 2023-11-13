using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int sprayCount = 0;
    [SerializeField] private Text sprayText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Spray"))
        {
            //collectionSoundEffect.Play();
            Destroy(obj);
            sprayCount++;

            sprayText.text = "Spray Count: " + sprayCount;
        }
    }
}
