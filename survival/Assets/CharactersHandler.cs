using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersHandler : MonoBehaviour
{
    public GameObject Characters;
    public GameObject CharacterPrefab;
    private List<PlayerData> _characters;

    List<GameObject> ListOfCharacters = new List<GameObject>();

    void Awake()
    {
        _characters = SaveLoadManager.GetPlayers();
    }

    void Start()
    {
        foreach(var character in _characters)
        {
            GameObject c = (GameObject)Instantiate(CharacterPrefab, new Vector3(0, 1, 0), Quaternion.identity, Characters.transform);
            c.GetComponent<NPC>().SetPlayerData(character);
            ListOfCharacters.Add(c);
        }
    }

    void Update()
    {
        foreach(GameObject character in ListOfCharacters)
        {
            if(MenuStateHandler.currentMenuState == MenuState.characterCreation)
            {
                character.SetActive(false);
            }
            else
            {
                character.SetActive(true);
            }
        }
    }
}
