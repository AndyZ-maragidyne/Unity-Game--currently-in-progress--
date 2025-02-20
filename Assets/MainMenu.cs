using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public PlayerDataSO playerLives;

    void Start()
    {
        playerLives.Lives = 3;
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }
}
