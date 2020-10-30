using Assets.Scripts.Menu.CharacterSelection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionBox : MonoBehaviour
{
    // Start is called before the first frame update
    public int characterId;
    public string Name;
    public int Body;
    public int SkinColor;
    public int Hair;
    public int HairColor;

    public double Health;
    public double Stamina;
    public double Hunger;
    public double Thirst;
    public double Radiation;
    public double Warm;
    public double Cold;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteCharacter()
    {
        SaveLoadManager.RemovePlayer(characterId);
        Destroy(gameObject);
    }

    public void SelectCharacter()
    {
        SceneManager.LoadScene("WorldSelection");
        PlayerHandler.SelectPlayer(characterId, Body, SkinColor, Hair, HairColor, Name);
        PlayerHandler.SetPlayerStats(Health, Stamina, Hunger, Thirst, Radiation, Warm, Cold);
    }
}
