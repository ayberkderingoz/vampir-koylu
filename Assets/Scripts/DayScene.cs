using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DayScene : MonoBehaviour
{
    public static string geceOlenler = "";
    void Start()
    {
        GeneralMethod.HandleNightEvents();
        VoteScreenManager.lastClicked = null;
        if (GeneralMethod.isThereWinner())
        {
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            List<string> oyuncuStatus = GeneralMethod.GetPlayersStatus();
            GameObject.Find("YasayanlarText").GetComponent<TMP_Text>().text = oyuncuStatus[0];
            GameObject.Find("OlulerText").GetComponent<TMP_Text>().text = oyuncuStatus[1];
            GameObject.Find("SkipDayButton").GetComponent<Button>().onClick.AddListener(onSkipDayButtonClick);
            GameObject.Find("VoteButton").GetComponent<Button>().onClick.AddListener(onVoteButtonClick);
            GameObject.Find("GeceOlenlerPanel").transform.GetChild(0).GetComponent<TMP_Text>().text = $"Bu gece olenler:{Environment.NewLine}{geceOlenler}";
        }
    }

    private void onSkipDayButtonClick()
    {
        SceneManager.LoadScene("StartNightScene");
    }

    private void onVoteButtonClick()
    {
        SceneManager.LoadScene("ChoosePlayer"); //vote ekranı geldi
    }
}
