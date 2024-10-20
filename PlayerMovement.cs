using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;      // Horizontal movement speed
    public float jumpForce = 12f;     // Force applied when jumping
    public float dampingFactor = 0.9f;
    private bool isGrounded = false;  // Check if the player is on the ground
    private Rigidbody2D rb;
    private bool facingRight = true;  // Track if player is facing right

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move left and right
        float moveInput = Input.GetAxis("Horizontal"); // Gets input from arrow keys or A/D keys
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if(moveInput != 0)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        }
        else 
        
        { rb.velocity = new Vector2(0, rb.velocity.y);
        
        }


        // Jump if player is grounded and the jump key is pressed (space bar by default)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x * 2f, jumpForce);

        }
        

    }

    // Check if the player is touching the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}