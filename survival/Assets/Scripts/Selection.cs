using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour
{
    public void SinglePlayer()
    {
        SceneManager.LoadScene(2);
    }

    public void HostGame()
    {
        SceneManager.LoadScene(1);
    }

    public void JoinGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
