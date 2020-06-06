using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Achievements()
    {
        SceneManager.LoadScene(6);
    }

    public void Settings()
    {
        SceneManager.LoadScene(7);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
