using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("padreTest");
    }

    public void Win()
    {
        SceneManager.LoadScene("VictoryScene");
    }

    public void Lose()
    {
        SceneManager.LoadScene("padreTest");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("padreTest");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
