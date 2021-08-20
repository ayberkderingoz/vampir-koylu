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
        if (textBox.text == "")
            playerCount.text = $"Oyuncu ismi bo� b�rak�lamaz. L�tfen {oyuncuList.Count + 1}. oyuncunun ismini giriniz.";
        else if (oyuncuList.Contains(textBox.text))
            playerCount.text = $"Ayn� isimde birden fazla oyuncu olamaz. L�tfen {oyuncuList.Count + 1}. oyuncunun ismini giriniz.";
        else
        {
            oyuncuList.Add(textBox.text);
            playerCount.text = $"L�tfen {oyuncuList.Count + 1}. oyuncunun ismini giriniz.";
        }
        textBox.text = "";

        if (oyuncuList.Count == oyuncuCount)
            Debug.Log("Ab oyuncular biddi.");

    }
}