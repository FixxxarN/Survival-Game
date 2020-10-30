using Assets.Scripts.World;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    PlayerController player;
    GameObject playerObject;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerObject = player.gameObject;
        InvokeRepeating("SaveWorld", 300, 300);
        InvokeRepeating("SavePlayer", 300, 300);
    }

    void OnApplicationQuit()
    {
        SaveWorld();
        SavePlayer();
    }

    private void SavePlayer()
    {
        Player p = new Player()
        {
            Id = PlayerHandler.Id,
            Gender = PlayerHandler.Body == 0 ? "Male" : "Female",
            Hair = PlayerHandler.Hair,
            HairColor = PlayerHandler.HairColor,
            SkinColor = PlayerHandler.SkinColor,
            Name = PlayerHandler.Name,
            Health = player.Health,
            Stamina = player.Stamina,
            Hunger = player.Hunger,
            Thirst = player.Thirst,
            Radiation = player.Radiation,
            Warm = player.Warm,
            Cold = player.Cold
        };

        SaveLoadManager.SavePlayer(p);
    }

    private void SaveWorld()
    {
        WorldGenerator.world.PlayerPositionX = playerObject.transform.position.x;
        WorldGenerator.world.PlayerPositionY = playerObject.transform.position.y;
        WorldGenerator.world.Chunks = WorldGenerator.chunks;
        SaveLoadManager.SaveWorld(WorldGenerator.world);
    }
}
