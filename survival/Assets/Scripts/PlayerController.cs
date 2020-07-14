using Assets.Scripts;
using Assets.Scripts.World;
using System;
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
    private ChunksHandler chunksHandler;

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
        gameObject.transform.position = new Vector3(WorldGenerator.world.PlayerPositionX, WorldGenerator.world.PlayerPositionY, 0);
        chunksHandler = FindObjectOfType<ChunksHandler>();
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
        RemoveBlock();
        PlaceBlock();
    }

    private void PlaceBlock()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit2d = Physics2D.Raycast(mousePosition, Vector2.zero);

            AddBlockInWorld(mousePosition);
            Instantiate(chunksHandler.IronPrefab, new Vector3((float)Math.Round(mousePosition.x * 8, MidpointRounding.AwayFromZero) / 8, (float)Math.Round(mousePosition.y * 8, MidpointRounding.AwayFromZero) / 8, 0), Quaternion.identity);
        }
    }

    private void RemoveBlock()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 c = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit2d = Physics2D.Raycast(c, Vector2.zero);

            if(hit2d)
            {
                if(hit2d.collider.CompareTag("Block"))
                {
                    RemoveBlockInWorld(c);
                    Destroy(hit2d.collider.gameObject);
                }
            }
        }
    }

    private void AddBlockInWorld(Vector3 mousePosition)
    {
        WorldGenerator.AddBlock(mousePosition);
    }

    private void RemoveBlockInWorld(Vector3 mousePosition)
    {
        WorldGenerator.RemoveBlock(mousePosition);
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
