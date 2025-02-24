using System;
using System.IO;
using UnityEngine;

public class dataManager : MonoBehaviour
{
    public static dataManager instance;
    public string playerName;
    public int playerScore;
    public string highScoreName;
    public int highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadNameAndScore();

    }
    [Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;
        public string highScoreName;
        public int highScore;
    }
    public void SaveNameAndScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScoreName = highScoreName;
        data.highScore = highScore;
        data.playerScore = playerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadNameAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }

}
