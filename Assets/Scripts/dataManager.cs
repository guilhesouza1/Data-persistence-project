using UnityEngine;

public class dataManager : MonoBehaviour
{
    public static dataManager instance;
    public string playerName;
    public int score;

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
    }
}
