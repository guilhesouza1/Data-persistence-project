using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class menuUIHandler : MonoBehaviour
{
    [SerializeField] Text playerNameInput;

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void SetPlayerName()
    {
        dataManager.instance.playerName = playerNameInput.text;
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
