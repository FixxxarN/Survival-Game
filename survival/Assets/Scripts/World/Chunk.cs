using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.World
{
    [Serializable]
    public class Chunk
    {
        [SerializeField]
        public int width, height;
        [SerializeField]
        public float x, y;

        [SerializeField]
        public int[,] blocks;

        [SerializeField]
        public long seed;

        public Chunk(int width, int height, float x, float y)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;

            seed = UnityEngine.Random.Range(0, 10000);
        }

        // Blocks, 0 = air, 1 = grass, 2 = dirt, 3 = stone, 4 = coal, 5 = iron;

        public void AddAir()
        {
            blocks = new int[width, height];
            for (int i = 0; i < blocks.GetLength(1); i++)
            {
                for (int j = 0; j < blocks.GetLength(0); j++)
                {
                    blocks[i, j] = 0;
                }
            }
        }

        public void AddGroundBlocks()
        {
            PerlinNoise noise = new PerlinNoise(seed);
            blocks = new int[width, height];
            for(int i = 0; i < blocks.GetLength(1); i++)
            {
                int columnHeight = noise.GetNoise(i, height);
                for(int j = 0; j < 0 + columnHeight; j++)
                {
                    blocks[i, j] = (j == 0 + columnHeight - 1) ? 1 : 2;

                    if (j < columnHeight - 6)
                    {
                        if (UnityEngine.Random.Range(0, 200) <= 0)
                        {
                            if (UnityEngine.Random.Range(0, 5) <= 0)
                            {
                                blocks[i, j] = 5;
                            }
                            else
                            {
                                blocks[i, j] = 4;

                            }
                        }
                        else
                            blocks[i, j] = 3;
                    }
                }
            }
        }

        public void AddUndergroundBlocks()
        {
            blocks = new int[width, height];
            for (int i = 0; i < blocks.GetLength(1); i++)
            {
                for (int j = 0; j < blocks.GetLength(0); j++)
                {
                    if(UnityEngine.Random.Range(0, 100) == 0)
                    {
                        blocks[i, j] = 4;
                    }
                    else
                    {
                        blocks[i, j] = 3;
                    }
                }
            }
        }
    }
}
