using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{
    // Start is called before the first frame update
    private Body body;
    private Hair hair;

    private InputField nameTextInput;

    void Start()
    {
        body = GetComponentInChildren<Body>();
        hair = GetComponentInChildren<Hair>();
        nameTextInput = GetComponentInChildren<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCharacter()
    {
        Player player = new Player
        {
            Id = SaveLoadManager.GetPlayers().Count,
            Name = nameTextInput.text,
            Gender = body.selectedGender == 0 ? "Male" : "Female",
            SkinColor = body.selectedColor,
            Hair = hair.selectedHair,
            HairColor = hair.selectedHairColor,
            Health = 100,
            Stamina = 100,
            Hunger = 100,
            Thirst = 100,
            Radiation = 0,
            Warm = 0,
            Cold = 0,
            Level = 1,
            XP = 0,
            Money = 0,
        };
        PlayerHandler.SelectPlayer(player.Id, body.selectedGender, player.SkinColor, player.Hair, player.HairColor, player.Name);
        PlayerHandler.SetPlayerStats(player.Health, player.Stamina, player.Hunger, player.Thirst, player.Radiation, player.Warm, player.Cold);
        SaveLoadManager.SavePlayer(player);
        SceneManager.LoadScene("WorldSelection");
    }
}
