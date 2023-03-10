using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class JumpDamage : MonoBehaviour
{
    public Collider2D collider2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject destroyParticle;

    [SerializeField] private float JumpForce;
    [SerializeField] private int lifes;
    [SerializeField] private AudioSource damageClip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * JumpForce);
            LoseLifeNHit();
            CheckLife();
            damageClip.Play();
        }
    }

    public void LoseLifeNHit()
    {
        lifes--;
        animator.Play("HitAnimation");
    }

    public void CheckLife()
    {
        if (lifes == 0)
        {
            destroyParticle.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
