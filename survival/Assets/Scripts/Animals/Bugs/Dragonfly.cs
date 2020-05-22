using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragonfly : Bug
{
    // Start is called before the first frame update
    void Start()
    {
        flyingSpeed = 0.5f;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flying();
    }
}
