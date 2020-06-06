using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager
{
    public static void SavePlayer(Player player)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/Characters"))
            Directory.CreateDirectory(Application.persistentDataPath + "/Characters");

        int id = GetPlayers().Count;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/Characters/" + id + ".data", FileMode.Create);

        PlayerData data = new PlayerData(player);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static List<PlayerData> GetPlayers()
    {
        List<PlayerData> data = new List<PlayerData>();
        for(int i = 0; i < Application.persistentDataPath.Length; i++)
        {
            if(File.Exists(Application.persistentDataPath + "/Characters/" + i + ".data"))
            {
                data.Add(LoadPlayer(i));
            }
        }
        return data;
    }

    public static PlayerData LoadPlayer(int i)
    {
        if(File.Exists(Application.persistentDataPath + "/Characters/" + i + ".data"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/Characters/" + i + ".data", FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("File does not exist");
            return new PlayerData(new Player());
        }
    }

    public static void RemovePlayer(int id)
    {
        if(File.Exists(Application.persistentDataPath + "/Characters/" + id + ".data"))
        {
            File.Delete(Application.persistentDataPath + "/Characters/" + id + ".data");
        }
        else
        {
            Debug.LogError("File does not exist");
        }
    }

    /* Worlds */
    public static void SaveWorld(World world)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/Worlds"))
            Directory.CreateDirectory(Application.persistentDataPath + "/Worlds");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/Worlds/" + "[World.Name]" + ".data", FileMode.Create);

        WorldData data = new WorldData(world);

        bf.Serialize(stream, data);
        stream.Close();
    }
}

[Serializable]
public class PlayerData
{
    public int Id;
    public string Name;
    public string Gender;
    public int SkinColor;
    public int Hair;
    public int HairColor;
    public int EyeColor;

    public PlayerData(Player player)
    {
        Id = player.Id;
        Name = player.Name;
        Gender = player.Gender;
        SkinColor = player.SkinColor;
        Hair = player.Hair;
        HairColor = player.HairColor;
        EyeColor = player.EyeColor;
    }
}

[Serializable]
public class WorldData
{
    public int Id;
    public string Name;

    public WorldData(World world)
    {

    }
}
