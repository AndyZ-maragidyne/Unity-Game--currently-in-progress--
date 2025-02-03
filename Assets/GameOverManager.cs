using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement; // For restarting the level
using UnityEngine.UI; // For interacting with UI elements

public class GameOverManager : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
        UnityEngine.Debug.Log("Game Over Menu active");

    }

    public void RestartButton()
    {
        UnityEngine.Debug.Log("Clicked");
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void ExitButton()
    {

    }
}