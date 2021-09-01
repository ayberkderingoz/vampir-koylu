using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartNight : MonoBehaviour
{
    public static int playerIndex = 0;
    [SerializeField] private TMP_Text geceText;

    private void Start()
    {
        if (NameSceneController.oyuncuList[playerIndex].IsDead)
        {
            playerIndex++;
            SceneManager.LoadScene("StartNightScene");
        }
        geceText.text = $"Telefonu {NameSceneController.oyuncuList[playerIndex].Name} adli oyuncuya verin.";
        GameObject.Find("GeceButton").GetComponent<Button>().onClick.AddListener(onPressGeceButton);
    }

    private void onPressGeceButton()
    {
        playerIndex++;
        SceneManager.LoadScene("Test");
    }
}
