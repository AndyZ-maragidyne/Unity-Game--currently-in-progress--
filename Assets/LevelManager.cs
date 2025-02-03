using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
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
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        Debug.Log("You win!!!!!! omg youre so god");
    }
}
