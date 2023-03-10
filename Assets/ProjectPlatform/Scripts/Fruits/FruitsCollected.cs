using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FruitsCollected : MonoBehaviour
{
    [SerializeField] private AudioSource fruitsClip;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            

            Destroy(gameObject, .7f);

            fruitsClip.Play();

        }
    }
}
