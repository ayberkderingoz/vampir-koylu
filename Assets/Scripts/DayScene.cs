using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DayScene : MonoBehaviour
{

    void Start()
    {
        List<string> oyuncuStatus = GeneralMethod.GetPlayersStatus();
        GameObject.Find("YasayanlarText").GetComponent<TMP_Text>().text = oyuncuStatus[0];
        GameObject.Find("OlulerText").GetComponent<TMP_Text>().text = oyuncuStatus[1];
        GameObject.Find("SkipDayButton").GetComponent<Button>().onClick.AddListener(onSkipDayButtonClick);
        GameObject.Find("VoteButton").GetComponent<Button>().onClick.AddListener(onVoteButtonClick);
    }

    private void onSkipDayButtonClick()
    {
        SceneManager.LoadScene("StartNightScene");
    }

    private void onVoteButtonClick()
    {
        SceneManager.LoadScene("Test"); //vote ekranı gelicek
    }
}
