using Assets.Scripts;
using Assets.Scripts.World;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunksHandler : MonoBehaviour
{
    public GameObject Chunk;

    public GameObject DirtPrefab;
    public GameObject GrassPrefab;
    public GameObject StonePrefab;
    public GameObject CoalPrefab;
    public GameObject IronPrefab;
    public GameObject AirPrefab;

    public CameraController CameraController;

    void Awake()
    {
        CameraController = FindObjectOfType<CameraController>();
    }

    void Start()
    {
        if(WorldGenerator.NewWorld)
        {
            WorldGenerator.CreateWorld();
        }
        else
        {

        }
        RenderChunks();
        RenderBlocks();
    }

    void FixedUpdate()
    {
        DrawVisibleChunks();
    }

    public void DrawVisibleChunks()
    {
        if (Camera.current != null)
        {
            foreach(GameObject chunk in WorldGenerator.ChunkObjects)
            {
                if (chunk.transform.position.x > Camera.current.transform.position.x - Camera.current.scaledPixelWidth / 100 / 2 - 4 &&
                       chunk.transform.position.x < Camera.current.transform.position.x + Camera.current.scaledPixelWidth / 100 / 2 + 4 &&
                       chunk.transform.position.y > Camera.current.transform.position.y - Camera.current.scaledPixelHeight / 100 / 2 - 4 &&
                       chunk.transform.position.y < Camera.current.transform.position.y + Camera.current.scaledPixelHeight / 100 / 2 + 4)
                {
                    chunk.SetActive(true);
                }
                else
                {
                    chunk.SetActive(false);
                }
            }
        }
    }


    public void RenderChunks()
    {
        WorldGenerator.ChunkObjects = new List<GameObject>();
        for (int i = 0; i < WorldGenerator.chunks.GetLength(1); i++)
        {
            for (int j = 0; j < WorldGenerator.chunks.GetLength(0); j++)
            {
                GameObject chunk = Instantiate(Chunk, new Vector3(WorldGenerator.chunks[j, i].x, WorldGenerator.chunks[j, i].y), Quaternion.identity);
                chunk.SetActive(false);
                WorldGenerator.ChunkObjects.Add(chunk);
            }
        }
    }

    public void RenderBlocks()
    {
        foreach(Chunk chunk in WorldGenerator.chunks)
        {
            for (int i = 0; i < chunk.width; i++)
            {
                for (int j = 0; j < chunk.height; j++)
                {
                    if (chunk.blocks[i, j] == 0)
                        continue;

                    GameObject block = Instantiate(GetBlockPrefab(chunk.blocks[i, j]), new Vector3(i * 0.125f + chunk.x, j * 0.125f + chunk.y), Quaternion.identity, WorldGenerator.ChunkObjects.FirstOrDefault(c => c.transform.position.x == chunk.x && c.transform.position.y == chunk.y).transform);
                }
            }
        }
    }

    public GameObject GetBlockPrefab(int block)
    {
        switch (block)
        {
            case 1:
                return GrassPrefab;
            case 2:
                return DirtPrefab;
            case 3:
                return StonePrefab;
            case 4:
                return CoalPrefab;
            case 5:
                return IronPrefab;
            default:
                return GrassPrefab;
        }
    }
}
