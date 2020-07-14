using Assets.Scripts.World;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            WorldGenerator.world.PlayerPositionX = player.transform.position.x;
            WorldGenerator.world.PlayerPositionY = player.transform.position.y;
            WorldGenerator.world.Chunks = WorldGenerator.chunks;
            SaveWorld(WorldGenerator.world);
        }
    }

    private void SaveWorld(World world)
    {
        SaveLoadManager.SaveWorld(world);
    }
}
