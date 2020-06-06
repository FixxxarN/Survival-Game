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

    void Awake()
    {
        characters = SaveLoadManager.GetPlayers();
        charactersText = GameObject.Find("Characters");
        charactersTextRect = charactersText.GetComponent<RectTransform>();
    }

    void Start()
    {
        int i = 1;
        foreach(PlayerData character in characters)
        {

            GameObject characterSelectionBox = (GameObject)Instantiate(CharacterSelectionBox, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
            characterSelectionBox.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, charactersTextRect.anchoredPosition.y - 100 * i - (i > 1 ? 50 : 0), 0);
            characterSelectionBox.GetComponent<CharacterSelectionBox>().characterId = character.Id;
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
            characterSelectionBox.gameObject.name = character.Name;
            i++;
        }
    }

    void Update()
    {
        
    }

    public void NavigateToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
