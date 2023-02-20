using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJump;
    [SerializeField] private bool playerBetterJump;
    [SerializeField] private float playerFallJump;
    [SerializeField] private float playerLowJump;

    Rigidbody2D playerRb;

    public SpriteRenderer spriteRenderer;
    public Animator animator;



    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            playerRb.velocity = new Vector2(playerSpeed, playerRb.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("isRunning", true);
        }
        
        else if (Input.GetKey("a"))
        {
            playerRb.velocity = new Vector2(-playerSpeed, playerRb.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("isRunning", true);
        }

        else
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
            animator.SetBool("isRunning", false);
        }
        if (Input.GetKey("space") && PlayerCheckGround.isGrounded)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerJump);           
        }

        if (PlayerCheckGround.isGrounded == false)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
        } 
        if (PlayerCheckGround.isGrounded == true)
        {
            animator.SetBool("isJumping", false);
            
        }

        if (playerBetterJump)
        {
            if (playerRb.velocity.y < 0)
            {
                playerRb.velocity += Vector2.up * Physics2D.gravity.y * (playerFallJump) * Time.deltaTime;
            }
            
            if (playerRb.velocity.y > 0 && !Input.GetKey("space"))
            {
                playerRb.velocity += Vector2.up * Physics2D.gravity.y * (playerLowJump) * Time.deltaTime;
            }
        }
    }

}
