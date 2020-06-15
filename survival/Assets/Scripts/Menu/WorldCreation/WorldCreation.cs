using Assets.Scripts.World;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldCreation : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        
    }

    public void CreateNewWorld(string size)
    {
        WorldGenerator.Size = size;
        WorldGenerator.NewWorld = true;
        WorldGenerator.Name = text.text;
        SceneManager.LoadScene("Ingame");
    }
}
