using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Health = 100f;

    public float movementSpeed = 5f;
    public float jumpHeight = 5f;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Rigidbody2D rigidbody;
    private Animator anim;

    public float YVelocity = 0.0f;

    public Inventory inventory;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Item")
        {
            inventory.AddItem(other.gameObject.GetComponent<Item>());
            //Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Ground" && other.relativeVelocity.y > 10)
        {
            Health -= other.relativeVelocity.y * rigidbody.gravityScale * 1.5f;
        }
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Update()
    {
        Movement();
        Jump();
        Save();
        Load();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight);
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                rigidbody.velocity = new Vector2(-movementSpeed * 2, rigidbody.velocity.y);
            else
                rigidbody.velocity = new Vector2(-movementSpeed, rigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                rigidbody.velocity = new Vector2(movementSpeed * 2, rigidbody.velocity.y);
            else
                rigidbody.velocity = new Vector2(movementSpeed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        anim.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));

        if (rigidbody.velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (rigidbody.velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    void Save()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            var player = GetComponent<Player>();
            SaveLoadManager.SavePlayer(player);
        }
    }

    void Load()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            var playerData = SaveLoadManager.LoadPlayer(1);
            var player = GetComponent<Player>();
            player.Name = playerData.Name;
        }
    }
}
