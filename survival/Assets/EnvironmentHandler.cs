using Assets.Scripts.World;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHandler : MonoBehaviour
{
    public GameObject Stick;
    public GameObject Stone;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var chunk in WorldGenerator.chunks)
        {
            foreach (var block in chunk.blocks)
            {
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
