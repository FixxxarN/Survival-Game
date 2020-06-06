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

    public List<GameObject> Chunks;

    PerlinNoise noise;
    // Start is called before the first frame update
    void Start()
    {
        Chunks = new List<GameObject>();
        CameraController = FindObjectOfType<CameraController>();
        chunkWidth = Chunk.GetComponent<ChunkGenerator>().maxX;
        noise = new PerlinNoise(Random.Range(1000000, 10000000));
        Generate();
    }

    void FixedUpdate()
    {
        DrawVisibleChunks();
    }

    public void DrawVisibleChunks()
    {
        if(Camera.current != null)
        {
            for(int i = 0; i < NumberOfChunks; i++)
            {
                if (Chunks[i].transform.position.x > Camera.current.transform.position.x - Camera.current.scaledPixelWidth / 100 / 2 - 4 &&
                    Chunks[i].transform.position.x < Camera.current.transform.position.x + Camera.current.scaledPixelWidth / 100 / 2 + 4 &&
                    Chunks[i].transform.position.y > Camera.current.transform.position.y - Camera.current.scaledPixelHeight / 100 / 2 - 4 &&
                    Chunks[i].transform.position.y < Camera.current.transform.position.y + Camera.current.scaledPixelHeight / 100 / 2 + 4) 
                {
                    Chunks[i].SetActive(true);
                }
                else
                {
                    Chunks[i].SetActive(false);
                }
            }
        }
    }

    public void Generate()
    {
        int lastX = (int)(Mathf.Round(-chunkWidth * 0.25f));
        for(int i = 0; i < NumberOfChunks; i++)
        {
            GameObject newChunk = Instantiate(Chunk, new Vector2(lastX + chunkWidth * 0.25f, 0f), Quaternion.identity) as GameObject;
            newChunk.GetComponent<ChunkGenerator>().noise = new PerlinNoise(Random.Range(1000000, 10000000));
            Chunks.Add(newChunk);
            lastX += (int)(Mathf.Round(chunkWidth * 0.25f));
        }
    }
}
