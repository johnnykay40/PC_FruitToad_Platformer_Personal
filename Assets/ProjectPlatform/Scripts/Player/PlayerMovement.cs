using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJump;

    Rigidbody2D playerRb;



    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            playerRb.velocity = new Vector2(playerSpeed, playerRb.velocity.y);
        }
        
        else if (Input.GetKey("a"))
        {
            playerRb.velocity = new Vector2(-playerSpeed, playerRb.velocity.y);
        }

        else
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }
        if (Input.GetKey("space") && PlayerCheckGround.isGrounded)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerJump);
        }
    }

}
