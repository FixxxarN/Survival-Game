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
        InvokeRepeating("SaveWorld", 300, 300);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            SaveWorld();
        }
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
