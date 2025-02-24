using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class GameOverUIHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
