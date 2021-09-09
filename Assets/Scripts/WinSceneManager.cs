using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinSceneManager : MonoBehaviour
{
    public static string victoriousTeam;
    public Color colorKoy;
    public Color colorVampir;

    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Main Camera").GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        if (victoriousTeam == "Koy")
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = colorKoy;
        
        else if (victoriousTeam == "Vampirler")
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = colorVampir; 
        
        GameObject.Find("WinnersText").GetComponent<TMP_Text>().text = getWinners();
        GameObject.Find("WinText").GetComponent<TMP_Text>().text = victoriousTeam + " Kazandi";
        GameObject.Find("restartButton").GetComponent<Button>().onClick.AddListener(RestartButtonClickedEvent);
        DayScene.geceOlenler = "";
    }

    private string getWinners()
    {
        string winners = "";
        if (victoriousTeam == "Koy")
        {
            foreach (var oyuncu in NameSceneController.oyuncuList)
            {
                if (oyuncu.role.ToString() == "Koylu" || oyuncu.role.ToString() == "Doktor" ||
                    oyuncu.role.ToString() == "Gozcu")
                {
                    winners += oyuncu.Name + Environment.NewLine;
                }
            }
           
        }
        else if (victoriousTeam == "Vampirler")
        {
            foreach (var oyuncu in NameSceneController.oyuncuList)
            {
                if (oyuncu.role.ToString() == "Vampir" || oyuncu.role.ToString() == "Basvampir")
                {
                    winners += oyuncu.Name + Environment.NewLine;
                }
            }
        }

        return winners;
    }

    private void RestartButtonClickedEvent()
    {
        StartNight.playerIndex = 0;
        SceneManager.LoadScene("StartScene");
    }
}
