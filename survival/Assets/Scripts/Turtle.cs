using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public float MoveSpeed;
    public bool MoveRight;

    public bool Idle = false;

    public float Timer = 0.0f;
    public int Seconds;

    private Rigidbody2D rigidbody;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RandomMovement();

        anim.SetBool("Idle", Idle);

        if (MoveRight)
        {
            rigidbody.velocity = new Vector2(MoveSpeed, rigidbody.velocity.y);
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            rigidbody.velocity = new Vector2(-MoveSpeed, rigidbody.velocity.y);
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void RandomMovement()
    {
        Timer += Time.deltaTime;
        Seconds = (int)(Timer % 60);

        if(Seconds > 3)
        {
            Timer = 0.0f;
            var random = Random.Range(0, 15);
            if (random < 5)
            {
                Idle = true;
                MoveSpeed = 0.0f;
            }
            else if(random > 4 && random < 10)
            {
                Idle = false;
                MoveSpeed = 0.2f;
                MoveRight = true;
            }
            else
            {
                Idle = false;
                MoveSpeed = 0.2f;
                MoveRight = false;
            }
        }
    }
}
