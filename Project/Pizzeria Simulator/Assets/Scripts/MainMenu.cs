using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChooseDifficulty()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void PlayGameEasy()
    {
        PlayerPrefs.SetString("difficulty", "easy");
        SceneManager.LoadSceneAsync(2);
    }

    public void PlayGameMedium()
    {
        PlayerPrefs.SetString("difficulty", "medium");
        SceneManager.LoadSceneAsync(2);
    }

    public void PlayGameHard()
    {
        PlayerPrefs.SetString("difficulty", "hard");
        SceneManager.LoadSceneAsync(2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}