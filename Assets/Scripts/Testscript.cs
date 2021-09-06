using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Testscript : MonoBehaviour
{
    private GameObject gameobj;
    public static int randInt { get; set; }
    public GameObject buttonPrefab;
    private Button playerButton;
    private Button skipButtonTest;
    private TMP_Text roleText;
    private Oyuncu lastClicked;
    private Oyuncu currentOyuncu;
    
    // Start is called before the first frame update
    void Start()
    {
        currentOyuncu = NameSceneController.oyuncuList[StartNight.playerIndex];
        gameobj = GameObject.Find("Content");
        skipButtonTest = GameObject.Find("SkipButtonTest").GetComponent<Button>();
        skipButtonTest.enabled = false;
        skipButtonTest.onClick.AddListener(onSkipButtonTestClickEvent);
        
        
        for (int i = 0; i < ButtonInteraction.totalOyuncuCount; i++)
        {
            GameObject button = (GameObject)Instantiate(buttonPrefab);
            button.transform.SetParent(gameobj.transform);
            button.transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 50f;
            button.transform.GetChild(0).GetComponent<TMP_Text>().text = NameSceneController.oyuncuList[i].Name;
            button.GetComponent<Button>().onClick.AddListener(onClickEvent);
        }
        roleText = GameObject.Find("RoleText").GetComponent<TMP_Text>();
        ChangeRoleText();
        HidePlayers();
        GameObject.Find("ScrollArea").GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
    }

    // Update is called once per frame
    private void onClickEvent()
    {
        lastClicked = GeneralMethod.GetPlayerByName(EventSystem.current.currentSelectedGameObject.transform.GetChild(0)
            .GetComponent<TMP_Text>().text);
        Debug.Log(lastClicked.Name);
        skipButtonTest.enabled = true;
        //Debug.Log(GeneralMethod.GetPlayerByName(EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TMP_Text>().text).role.ToString());
    }

    private void onSkipButtonTestClickEvent()
    {
        if (currentOyuncu.role.StartNightEvent(lastClicked))
        {
            if (StartNight.playerIndex == NameSceneController.oyuncuList.Count-1)
            {
                StartNight.playerIndex = 0;
                SceneManager.LoadScene("StartDayScene");
            }
            else
            {
                StartNight.playerIndex++;
                SceneManager.LoadScene("StartNightScene");
            }
        }
    }

    private void HidePlayerButton()
    {
        for (int i = 0; i < NameSceneController.oyuncuList.Count; i++)
        {
            playerButton = GameObject.Find("Content").transform.GetChild(i).GetComponent<Button>();
            if (NameSceneController.oyuncuList[StartNight.playerIndex].Name == playerButton.transform.GetChild(0).GetComponent<TMP_Text>().text)
            {
                playerButton.gameObject.SetActive(false);
            }
            
        }
    }

    private void HidePlayers()
    {
        HidePlayerButton();
        HideVampires();
        HideDeadPlayers();
    }

    private void HideDeadPlayers()
    {
        for (int i = 0; i < NameSceneController.oyuncuList.Count; i++)
        {
            playerButton = GameObject.Find("Content").transform.GetChild(i).GetComponent<Button>();
            if (NameSceneController.oyuncuList[i].IsDead)
            {
                playerButton.gameObject.SetActive(false);
            }
            
        }
    }
    private void HideVampires()
    {
        if (currentOyuncu.role.ToString() == "Basvampir" || currentOyuncu.role.ToString() == "Vampir")
        {
            for(int i=0;i<NameSceneController.oyuncuList.Count;i++)
            {
                if (NameSceneController.oyuncuList[i].role.ToString() == "Basvampir" || NameSceneController.oyuncuList[i].role.ToString() == "Vampir")
                {
                    playerButton = GameObject.Find("Content").transform.GetChild(i).GetComponent<Button>();
                    playerButton.gameObject.SetActive(false);
                }
            }
        }
    }

    private void ChangeRoleText()
    {
        if (currentOyuncu.role.ToString() == "Basvampir")
        {
            roleText.text = "Oldurucegin kisiyi sec";
        }
        else if (currentOyuncu.role.ToString() == "Vampir")
        {
            roleText.text = "Basvampire oldurmek istedigin kisiyi tanit";
        }
        else if (currentOyuncu.role.ToString() == "Koylu")
        {
            System.Random rnd = new System.Random();
            randInt = rnd.Next(NameSceneController.oyuncuList.Count);
            roleText.text = $"{NameSceneController.oyuncuList[randInt].Name} isimli oyuncuya tikla";
        }
        else if (currentOyuncu.role.ToString() == "Doktor")
        {
            roleText.text = "Korumak istedigin kisiyi sec";
        }
        else if (currentOyuncu.role.ToString() == "Gozcu")
        {
            roleText.text = "Rolunu Ogrenmek istedigin kisiyi sec";
        }
    }
}
