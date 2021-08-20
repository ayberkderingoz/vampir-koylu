using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameSceneController : MonoBehaviour
{
    [SerializeField] private TMP_InputField textBox;
    [SerializeField] private TextMeshProUGUI playerCount;
    public static List<string> oyuncuList;


    void Start()
    {
        oyuncuList = new List<string>();
    }
    public void onPressSkipButton()
    {
        var username = textBox.text;
        string playerCountText;

        int playerIndex = oyuncuList.Count + 1;
        
        if (string.IsNullOrEmpty( username))
            playerCountText = $"Oyuncu ismi bo� b�rak�lamaz. L�tfen {playerIndex}. oyuncunun ismini giriniz.";
        else if (oyuncuList.Contains(username))
            playerCountText= $"Ayn� isimde birden fazla oyuncu olamaz. L�tfen {playerIndex}. oyuncunun ismini giriniz.";
        else
        {
            oyuncuList.Add(username);
            playerCountText = $"L�tfen {playerIndex}. oyuncunun ismini giriniz.";
        }
        
        textBox.text = "";
        playerCount.text = playerCountText;
        
        if (oyuncuList.Count == ButtonInteraction.totalOyuncuCount)
            Debug.Log("Ab oyuncular biddi.");

    }
}