using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpHeight = 5f;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Update()
    {
        Movement();
        Jump();
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight);
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-movementSpeed, rigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(movementSpeed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
    }
}
