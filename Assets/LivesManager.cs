using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesManager : MonoBehaviour
{
    public PlayerScript PlayerScript;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI coinsText;
    public int currentLives;

    // Start is called before the first frame update
    void Start()
    {
        int currentLives = PlayerScript.lives;
        livesText.text = "Lives: " + PlayerScript.lives;
    }

    void UpdateLivesText()
    {
        livesText.text = "Lives: " + PlayerScript.lives;
    }

    void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + PlayerScript.coins;
    }


    // Update is called once per frame
    void Update()
    {
   
            UpdateLivesText();
        UpdateCoinsText();


    }
}
