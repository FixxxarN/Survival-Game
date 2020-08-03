using Assets.Scripts.World;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("SaveWorld", 300, 300);
    }

    void OnApplicationQuit()
    {
        SaveWorld();
    }

    private void SaveWorld()
    {
        WorldGenerator.world.PlayerPositionX = player.transform.position.x;
        WorldGenerator.world.PlayerPositionY = player.transform.position.y;
        WorldGenerator.world.Chunks = WorldGenerator.chunks;
        SaveLoadManager.SaveWorld(WorldGenerator.world);
    }
}
