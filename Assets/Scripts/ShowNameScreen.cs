using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
        skipButton = GameObject.Find("ShowButton").GetComponent<Button>();
    }


    public void onPressButton()
    {
        if (skipButton.GetComponent<TMP_Text>().text == "Goster")
        {
            skipButton.GetComponent<TMP_Text>().text = $"{NameSceneController.oyuncuList[playerIndex]} adli oyuncunun rolu ";
            

            skipButton.GetComponent<TMP_Text>().text = "Sonraki";
        }
        else
        {
            
        }
            
    }
}
