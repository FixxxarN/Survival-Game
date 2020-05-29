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
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Create);

        PlayerData data = new PlayerData(player);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        if(File.Exists(Application.persistentDataPath + "/player.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Open);

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
}

[Serializable]
public class PlayerData
{
    public string Name;
    public string Gender;
    public int SkinColor;
    public int Hair;
    public int HairColor;
    public int EyeColor;

    public PlayerData(Player player)
    {
        Name = player.Name;
        Gender = player.Gender;
        SkinColor = player.SkinColor;
        Hair = player.Hair;
        HairColor = player.HairColor;
        EyeColor = player.EyeColor;
    }
}
