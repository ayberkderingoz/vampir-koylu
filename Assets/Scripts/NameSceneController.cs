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
    public int oyuncuCount;
    private int oyuncuSayac;


    void Start()
    {
        oyuncuCount = ButtonInteraction.BasvampirCount + ButtonInteraction.VampirCount + ButtonInteraction.KoyluCount + ButtonInteraction.DoktorCount + ButtonInteraction.GozcuCount;
        oyuncuSayac = 0;
        oyuncuList = new List<string>();
    }
    public void onPressSkipButton()
    {
        oyuncuList.Add(textBox.text);
        textBox.text = "";
        playerCount.text = (oyuncuList.Count+1) + ". oyuncunun ismini girin";

    }
}