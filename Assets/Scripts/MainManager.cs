using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text HighScoreText;
    public GameObject GameOverText;
    public int highScore;

    private bool m_Started = false;
    public int m_Points;

    private bool m_GameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        ScoreText.text = $"{dataManager.instance.playerName} : 0";
        if (dataManager.instance.playerName == "")
            {
                dataManager.instance.playerName = "nobody";
            }
        HighScoreText.text = $"Best score: {dataManager.instance.highScoreName} : {dataManager.instance.highScore}";
        if (dataManager.instance.highScoreName == "")
            {
                dataManager.instance.highScoreName = "nobody";
            }
    }
    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;

        ScoreText.text = $"{dataManager.instance.playerName} : {m_Points}";
   
        if (m_Points > dataManager.instance.highScore) // If the current score is more than the last saved high score...
        {
            dataManager.instance.highScore = m_Points; // Set the high score to the current score
            HighScoreText.text = $"Best score: {dataManager.instance.playerName} : {m_Points}";

            if (dataManager.instance.playerName != dataManager.instance.highScoreName) // If the current name isn't the same as the last saved name...
            {
                // Set the saved name to be the same as the current name
                dataManager.instance.highScoreName = dataManager.instance.playerName;
            }
            dataManager.instance.SaveNameAndScore();
        }

        else if (dataManager.instance.playerScore >= dataManager.instance.highScore) // If the current score is higher or the same as the saved high score...
        {
            // Set the saved high score to the highScore
            dataManager.instance.highScore = highScore;
            HighScoreText.text = $"Best score: {dataManager.instance.highScoreName} : {dataManager.instance.highScore}";
            dataManager.instance.SaveNameAndScore();
        }

    }
    public void GameOver()
    {
        //dataManager.instance.SaveNameAndScore();
        m_GameOver = true;
        GameOverText.SetActive(true);
    }
}
