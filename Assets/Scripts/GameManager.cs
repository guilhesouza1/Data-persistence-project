using System;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public int highScore;
    public bool gameOver;
    public string currentHighScoreName;


    // Remember to drag the Score text gameObject into the Inpector of the empty GameObject connected to this script
    public Text scoreText;
    public Text currentHighScoreText;


    void Awake()
    {
        gameOver = false;

        // Displays the High Score Name and the High Score
        currentHighScoreText.text = "Best score: " + dataManager.instance.highScoreName + ": " + dataManager.instance.highScore;

        // If no-one's got a high score yet, display "nobody" as the name
        if(dataManager.instance.highScoreName == "")
        {
            dataManager.instance.highScoreName = "nobody";
        }

    }
    void Update()
    {
    SetHighScore();
    }
   private void SetHighScore()
    {
        if(score > dataManager.instance.highScore) // If the current score is more than the last saved high score...
        {

            highScore = score; // Set the high score to the current score
            currentHighScoreName = dataManager.instance.playerName; // Set the high score name to the player's current name


            if(dataManager.instance.playerName != dataManager.instance.highScoreName) // If the current name isn't the same as the last saved name...
            {
                // Set the saved name to be the same as the current name
                dataManager.instance.highScoreName = dataManager.instance.playerName;
            }

            if (dataManager.instance.playerScore >= dataManager.instance.highScore) // If the current score is higher or the same as the saved high score...
            {
                // Set the saved high score to the highScore
                dataManager.instance.highScore = highScore;
            }

            // Update the high score display
            currentHighScoreText.text = "Best score: " + dataManager.instance.highScoreName + ": " + dataManager.instance.highScore;

        }
    }
}
