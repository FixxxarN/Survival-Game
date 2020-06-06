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
            HairColor = hair.selectedHairColor
        };
        SaveLoadManager.SavePlayer(player);
        SceneManager.LoadScene("WorldSelection");
    }
}
