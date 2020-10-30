using Assets.Scripts.Menu.CharacterSelection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject CharacterSelectionBox;

    private List<PlayerData> characters;

    private GameObject charactersText;
    private RectTransform charactersTextRect;
    public GameObject Characters;

    void Awake()
    {
        characters = SaveLoadManager.GetPlayers();
        charactersText = GameObject.Find("Characters");
        charactersTextRect = charactersText.GetComponent<RectTransform>();
    }

    void Start()
    {
        int i = 0;
        foreach(PlayerData character in characters)
        {

            GameObject characterSelectionBox = (GameObject)Instantiate(CharacterSelectionBox, new Vector3(0, 0, 0), Quaternion.identity, Characters.gameObject.transform);
            characterSelectionBox.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, charactersTextRect.anchoredPosition.y - 50 - (i > 0 ? i * 150 : 0), 0);
            CharacterSelectionBox characterSelectionBoxClass = characterSelectionBox.GetComponent<CharacterSelectionBox>();
            CharacterSelectionBoxBody body = characterSelectionBox.GetComponentInChildren<CharacterSelectionBoxBody>();
            CharacterSelectionBoxHair hair = characterSelectionBox.GetComponentInChildren<CharacterSelectionBoxHair>();
            Text text = characterSelectionBox.GetComponentInChildren<Text>();
            text.text = character.Name;
            body.selectedGender = character.Gender == "Male" ? 0 : 1;
            body.selectedColor = character.SkinColor;
            hair.selectedHair = character.Hair;
            hair.selectedHairColor = character.HairColor;
            body.updateSprite = true;
            body.updateSkinColor = true;
            hair.updateHair = true;
            hair.updateHairColor = true;
            characterSelectionBoxClass.characterId = character.Id;
            characterSelectionBoxClass.Name = character.Name;
            characterSelectionBoxClass.Body = body.selectedGender;
            characterSelectionBoxClass.SkinColor = body.selectedColor;
            characterSelectionBoxClass.Hair = hair.selectedHair;
            characterSelectionBoxClass.HairColor = hair.selectedHairColor;
            characterSelectionBoxClass.Health = character.Health;
            characterSelectionBoxClass.Stamina = character.Stamina;
            characterSelectionBoxClass.Hunger = character.Hunger;
            characterSelectionBoxClass.Thirst = character.Thirst;
            characterSelectionBoxClass.Radiation = character.Radiation;
            characterSelectionBoxClass.Warm = character.Warm;
            characterSelectionBoxClass.Cold = character.Cold;
            characterSelectionBox.gameObject.name = character.Name;
            i++;
        }
    }
}
