using Assets.Scripts.World;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
	public int Id;
	public string Name;
	public string Size;
	public Chunk[,] Chunks;
	public float PlayerPositionX;
	public float PlayerPositionY;

	public World()
	{
	}
}