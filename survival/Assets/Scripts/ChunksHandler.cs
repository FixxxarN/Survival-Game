using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksHandler : MonoBehaviour
{
    public GameObject Chunk;
    int chunkWidth;
    public int NumberOfChunks;

    public CameraController CameraController;

    PerlinNoise noise;
    // Start is called before the first frame update
    void Start()
    {
        CameraController = FindObjectOfType<CameraController>();
        chunkWidth = Chunk.GetComponent<ChunkGenerator>().maxX;
        noise = new PerlinNoise(Random.Range(1000000, 10000000));
        Generate();
    }

    //void Update()
    //{
    //    DrawVisibleChunks();
    //}

    //public void DrawVisibleChunks()
    //{
    //    var camera = CameraController.gameObject;
        
    //    if()
    //}

    public void Generate()
    {
        int lastX = (int)(Mathf.Round(-chunkWidth * 0.25f));
        for(int i = 0; i < NumberOfChunks; i++)
        {
            GameObject newChunk = Instantiate(Chunk, new Vector2(lastX + chunkWidth * 0.25f, 0f), Quaternion.identity) as GameObject;
            newChunk.GetComponent<ChunkGenerator>().noise = new PerlinNoise(Random.Range(1000000, 10000000));
            lastX += (int)(Mathf.Round(chunkWidth * 0.25f));
        }
    }
}
