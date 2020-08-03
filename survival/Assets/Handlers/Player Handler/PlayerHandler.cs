using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerHandler
{
    public static int Body;
    public static int SkinColor;
    public static int Hair;
    public static int HairColor;
    public static string Name;

    public static void SelectPlayer(int body, int skinColor, int hair, int hairColor, string name)
    {
        Body = body;
        SkinColor = skinColor;
        Hair = hair;
        HairColor = hairColor;
        Name = name;
    }
}
