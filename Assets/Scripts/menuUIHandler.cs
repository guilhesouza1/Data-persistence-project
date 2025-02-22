using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class menuUIHandler : MonoBehaviour
{
    public GameObject playerNameInput;

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void SetPlayerName()
    {
        string playerNametxt = playerNameInput.GetComponent<TMP_InputField>().text;
        dataManager.instance.playerName = playerNametxt;
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
