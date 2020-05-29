using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    protected float flyingSpeed;
    protected bool alive = true;
    protected Rigidbody2D rigidbody;
    protected Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Flying function
    protected void Flying()
    {
        RandomMovement();
    }

    void RandomMovement()
    {
        int randomNumber = Random.Range(0, 20);
        if (randomNumber < 5)
        {
            rigidbody.velocity = new Vector2(-flyingSpeed, rigidbody.velocity.y);
        }
        else if (randomNumber > 4 && randomNumber < 10)
        {
            rigidbody.velocity = new Vector2(flyingSpeed, rigidbody.velocity.y);
        }
        else if (randomNumber > 9 && randomNumber < 15)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -flyingSpeed);
        }
        else
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, flyingSpeed);
        }
    }
}
