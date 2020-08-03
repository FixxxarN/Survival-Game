using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public List<Transform> blocks;
    private ChunksHandler chunksHandler;

    void Start()
    {
        chunksHandler = FindObjectOfType<ChunksHandler>();
        foreach(Transform child in transform)
        {
            blocks.Add(child);
        }
    }

    void Update()
    {
        
    }
}
