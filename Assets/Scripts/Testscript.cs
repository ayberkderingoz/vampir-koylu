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
            GameObject button = (GameObject)Instantiate(buttonPrefab, gameobj.transform,false);
            button.transform.GetChild(0).GetComponent<TMP_Text>().text = NameSceneController.oyuncuList[i].Name;
            button.GetComponent<Button>().onClick.AddListener(onClickEvent);
            if (currentOyuncu.role.ToString() == "Vampir" || currentOyuncu.role.ToString() == "Basvampir")
            {
                button.transform.GetChild(1).GetComponent<TMP_Text>().text =
                    NameSceneController.oyuncuList[i].voteCount.ToString();
            }
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
        if (currentOyuncu.role.ToString() == "Gozcu")
        {
            if (skipButtonTest.transform.GetChild(0).GetComponent<TMP_Text>().text == "Sonraki")
            {
                currentOyuncu.role.StartNightEvent(lastClicked);
                skipButtonTest.transform.GetChild(0).GetComponent<TMP_Text>().text = "Tamam";
            }
            else
            {
                if (StartNight.playerIndex == NameSceneController.oyuncuList.Count - 1)
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

        else
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
    }
    private void HidePlayerButton()
    {
        for (int i = 0; i < NameSceneController.oyuncuList.Count; i++)
        {
            playerButton = GameObject.Find("Content").transform.GetChild(i).GetComponent<Button>();
            if (NameSceneController.oyuncuList[StartNight.playerIndex].Name == playerButton.transform.GetChild(0).GetComponent<TMP_Text>().text)
            {
                if (currentOyuncu.role.ToString() != "Doktor" || (((Doktor)currentOyuncu.role)).selfProtect == 0)
                {
                    playerButton.gameObject.SetActive(false);
                }
            }
            
        }
    }
    private void HideButtonsDoktor()
    {
        for (int i = 0; i < NameSceneController.oyuncuList.Count; i++)
        {
            if (NameSceneController.oyuncuList[i] == currentOyuncu)
            {
                playerButton = GameObject.Find("Content").transform.GetChild(i).GetComponent<Button>();
                break;
            }
        }
        if ((((Doktor)currentOyuncu.role)).selfProtect == 0)
        {
            playerButton.gameObject.SetActive(false);
        }
        if ((((Doktor)currentOyuncu.role)).lastProtected != null)
        {
            for (int i = 0; i < NameSceneController.oyuncuList.Count; i++)
            {
                playerButton = GameObject.Find("Content").transform.GetChild(i).GetComponent<Button>();
                if ((((Doktor)currentOyuncu.role)).lastProtected.Name == playerButton.transform.GetChild(0).GetComponent<TMP_Text>().text)
                {
                    playerButton.gameObject.SetActive(false);
                }
            }
        }
    }
    private void HidePlayers()
    {
        HidePlayerButton();
        HideVampires();
        HideDeadPlayers();
        if(currentOyuncu.role.ToString() == "Doktor")
            HideButtonsDoktor();
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
            roleText.text = "Oldurmek icin oy vericegin kisiyi sec - 2 oy";
        }
        else if (currentOyuncu.role.ToString() == "Vampir")
        {
            roleText.text = "Oldurmek icin oy vericegin kisiyi sec - 1 oy";
        }
        else if (currentOyuncu.role.ToString() == "Koylu" || (currentOyuncu.role.ToString() == "Soytari" && currentOyuncu.IsDead == false))
        {
            randInt = GeneralMethod.GetARandomAlivePlayersIndex();
            roleText.text = $"{NameSceneController.oyuncuList[randInt].Name} isimli oyuncuya tikla";
        }
        else if (currentOyuncu.role.ToString() == "Soytari" && currentOyuncu.IsDead && (((Soytari)currentOyuncu.role).shouldKillSomeone = true))
        {
            roleText.text = "Öç almak istediğin kişiyi seç"; 
        }
        else if (currentOyuncu.role.ToString() == "Doktor")
        {
            roleText.text = "Korumak istedigin kisiyi sec"+Environment.NewLine + "Kendini sadece 1 kere koruyabilirsin, art arda 2 kere aynı kişiyi koruyamazsın";
        }
        else if (currentOyuncu.role.ToString() == "Gozcu")
        {
            roleText.text = "Rolunu ogrenmek istedigin kisiyi sec";
        }
        else if (currentOyuncu.role.ToString() == "Seri Katil")
        {
            roleText.text = "Katletmek istediğin oyuncuyu seç";
        }
    }


}
