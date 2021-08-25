using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameSceneController : MonoBehaviour
{
    [SerializeField] private TMP_InputField textBox;
    [SerializeField] private TextMeshProUGUI playerCount;
    public static List<ParentRole> oyuncuList;
    public static ParentRole LastInputtedPlayer;



    void Start()
    {
        oyuncuList = new List<ParentRole>();
    }
    public void onPressSkipButton()
    {
        var username = textBox.text;
        string playerCountText;

        int playerIndex = oyuncuList.Count + 1;
        
        if (string.IsNullOrEmpty(username))
            playerCountText = $"Oyuncu ismi bos birakilamaz. Lutfen {playerIndex}. oyuncunun ismini giriniz.";
        else if (GeneralMethod.GetNames(oyuncuList).Contains(username))
            playerCountText= $"Ayni isimde birden fazla oyuncu olamaz. Lutfen {playerIndex}. oyuncunun ismini giriniz.";
        else
        {
            LastInputtedPlayer.Name = username;
            oyuncuList.Add(LastInputtedPlayer);
            if (oyuncuList.Count == ButtonInteraction.totalOyuncuCount)
                SceneManager.LoadScene("Test");
            playerCountText = $"Lutfen {playerIndex+1}. oyuncunun ismini giriniz.";
        }
        
        textBox.text = "";
        playerCount.text = playerCountText;

        

    }
}