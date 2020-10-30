using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerHandler
{
    public static int Id;

    public static int Body;
    public static int SkinColor;
    public static int Hair;
    public static int HairColor;
    public static string Name;

    public static double Health;
    public static double Stamina;
    public static double Hunger;
    public static double Thirst;
    public static double Radiation;
    public static double Warm;
    public static double Cold;

    public static void SelectPlayer(int id, int body, int skinColor, int hair, int hairColor, string name)
    {
        Id = id;
        Body = body;
        SkinColor = skinColor;
        Hair = hair;
        HairColor = hairColor;
        Name = name;
    }

    public static void SetPlayerStats(double health, double stamina, double hunger, double thirst, double radiation, double warm, double cold)
    {
        Health = health;
        Stamina = stamina;
        Hunger = hunger;
        Thirst = thirst;
        Radiation = radiation;
        Warm = warm;
        Cold = cold;
    }
}
