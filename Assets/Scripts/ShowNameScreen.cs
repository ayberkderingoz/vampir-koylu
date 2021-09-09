using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowNameScreen : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_Text playerText;
    private Button skipButton;
    private int playerIndex = 0;
    void Start()
    {
        playerText = GameObject.Find("PlayerNameText").GetComponent<TMP_Text>();
        playerText.text = $"Telefonu {NameSceneController.oyuncuList[playerIndex].Name} adli oyuncuya verin.";
        skipButton = GameObject.Find("ShowButton").GetComponent<Button>();
        skipButton.onClick.AddListener(onPressButton);
    }
    
    public void onPressButton()
    {
        var buttonText = skipButton.transform.GetChild(0).GetComponent<TMP_Text>();
        if (buttonText.text == "Goster")
        {
            
            playerText.text = $"{NameSceneController.oyuncuList[playerIndex].Name} adli oyuncunun rolu {NameSceneController.oyuncuList[playerIndex].role}";
            if (NameSceneController.oyuncuList[playerIndex].role.ToString() == "Basvampir" || NameSceneController.oyuncuList[playerIndex].role.ToString() == "Vampir")
            {
                playerText.text += $"{Environment.NewLine}{Environment.NewLine}Vampirler:{Environment.NewLine}{Environment.NewLine}{GeneralMethod.GetVampiresNames()}";
            }
            playerIndex++;
            buttonText.text = "Sonraki";

        }
        else
        {
            if (NameSceneController.oyuncuList.Count == playerIndex)
            {
                if (buttonText.text == "Sonraki")
                {
                    playerText.text = "Oyunu baslatmak icin butona tiklayin";
                    buttonText.text = "Baslat";
                }
                else
                {
                    SceneManager.LoadScene("StartDayScene");
                }
            }
            else
            {
                playerText.text = $"Telefonu {NameSceneController.oyuncuList[playerIndex].Name} adli oyuncuya verin.";
                buttonText.text = "Goster";

            }
        }
            
    }
}
