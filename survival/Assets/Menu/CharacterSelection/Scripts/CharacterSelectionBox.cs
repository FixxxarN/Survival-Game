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
        PlayerHandler.SelectPlayer(Body, SkinColor, Hair, HairColor, Name);
    }
}
