using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("AustinDevScene");
    }

    public void CreditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}        
