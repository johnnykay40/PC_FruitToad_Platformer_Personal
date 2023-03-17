using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private float jumpForce;
    [SerializeField] private AudioSource jumpClip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            animator.Play("JumpTrampolineAnimation");
            jumpClip.Play();
        }
    }
}
