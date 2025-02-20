using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForEnemies();
    }

    void CheckForEnemies()
    {
        // Find all GameObjects tagged as "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // If no enemies are left, move to the next level
        if (enemies.Length == 0)
        {
            Invoke("LoadNextLevel", 3f);
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync("Level " + (currentLevel++));
    }
}
