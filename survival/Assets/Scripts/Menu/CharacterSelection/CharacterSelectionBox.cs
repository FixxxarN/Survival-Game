using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionBox : MonoBehaviour
{
    // Start is called before the first frame update
    public int characterId;

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
    }
}
