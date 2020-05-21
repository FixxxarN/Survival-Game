﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public GameObject DirtPrefab;
    public GameObject GrassPrefab;
    public GameObject StonePrefab;

    public int width;

    public int minX = -16;
    public int maxX = 16;
    public int minY = -16;
    public int maxY = 16;

    public PerlinNoise noise;

    void Start()
    {
        Generate();
    }

    private void Generate()
    {
        //Columns X
        for (int i = minX; i < maxX; i++)
        {
            //2 + noise
            int columnHeight = noise.GetNoise(i - minX, maxY - minY);
            //Rows Y
            for (int j = minY; j < minY + columnHeight; j++)
            {
                GameObject block = (j == minY + columnHeight - 1) ? GrassPrefab : DirtPrefab;

                if(j < minY + columnHeight - 6)
                {
                    block = StonePrefab;
                }
                GameObject newTile = Instantiate(block, Vector2.zero, Quaternion.identity);
                newTile.transform.parent = this.gameObject.transform;
                newTile.transform.localPosition = new Vector2(i * 0.125f, j * 0.125f);
            }
        }
    }
}