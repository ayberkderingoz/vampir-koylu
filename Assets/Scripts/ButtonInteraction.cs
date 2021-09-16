using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI BasvampirCountText;
    [SerializeField] private TextMeshProUGUI VampirCountText;
    [SerializeField] private TextMeshProUGUI KoyluCountText;
    [SerializeField] private TextMeshProUGUI DoktorCountText;
    [SerializeField] private TextMeshProUGUI GozcuCountText;
    [SerializeField] private TextMeshProUGUI SoytariCountText;

    public static int BasvampirCount;
    public static int VampirCount;
    public static int KoyluCount;
    public static int DoktorCount;
    public static int GozcuCount;
    public static int SoytariCount;
    public static int totalOyuncuCount;

    private Button basvampirButonArttir;
    private Button vampirButonArttir;
    private Button vampirButonAzalt;
    private TMP_Text ErrorMessage;


    void Start()
    {
        // Getting the buttons.
        basvampirButonArttir = GameObject.Find("ButtonBasvampirArtir").GetComponent<Button>();
        vampirButonArttir = GameObject.Find("ButtonVampirArtir").GetComponent<Button>();
        vampirButonAzalt = GameObject.Find("ButtonVampirAzalt").GetComponent<Button>();
        ErrorMessage = GameObject.Find("ErrorMessage").GetComponent<TMP_Text>();
        

        // Setting buttons noniteractable so at the start of the game, those buttons become not clickable.
        vampirButonArttir.interactable = false;
        vampirButonAzalt.interactable = false;
        ErrorMessage.gameObject.SetActive(false);
    }
    public void onPressIncreaseButton()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "ButtonBasvampirArtir")
        {
            // Checking the basvampir count.
            int BasvampirCountCheck = int.Parse(BasvampirCountText.text);
            if (BasvampirCountCheck == 0)
            {
                increaseCount(BasvampirCountText);

                // Setting buttons interactable because now basvampir count is 1.
                vampirButonArttir.interactable = true;
                vampirButonAzalt.interactable = true;

                // Setting the button noninteractable because max count of the basvampir is 1.
                basvampirButonArttir.interactable = false;
            }
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "ButtonVampirArtir")
        {
            increaseCount(VampirCountText);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "ButtonKoyluArtir")
        {
            increaseCount(KoyluCountText);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "ButtonDoktorArtir")
        {
            increaseCount(DoktorCountText);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "ButtonGozcuArtir")
        {
            increaseCount(GozcuCountText);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "ButtonSoytariArtir")
        {
            increaseCount(SoytariCountText);
        }
        
    }

    public void onPressDecreaseButton()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "ButtonBasvampirAzalt")
        {
            // Checking the basvampir count.
            int BasvampirCountCheck = int.Parse(BasvampirCountText.text);
            if (BasvampirCountCheck == 1)
            {
                decreaseCount(BasvampirCountText);

                // Setting buttons noninteractable because now basvampir count is 0.
                vampirButonArttir.interactable = false;
                vampirButonAzalt.interactable = false;

                // Setting the button interactable because now basvampir count is 0.
                basvampirButonArttir.interactable = true;

                // Setting the vampir count 0 because now basvampir count is 0 and without basvampir there can't be any vampire.
                VampirCountText.text = "0";
            }
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "ButtonVampirAzalt")
        {
            decreaseCount(VampirCountText);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "ButtonKoyluAzalt")
        {
            decreaseCount(KoyluCountText);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "ButtonDoktorAzalt")
        {
            decreaseCount(DoktorCountText);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "ButtonGozcuAzalt")
        {
            decreaseCount(GozcuCountText);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "ButtonSoytariAzalt")
        {
            decreaseCount(SoytariCountText);
        }
    }
    

    private void increaseCount(TextMeshProUGUI textBox)
    {
        int count;
        if (textBox.text == "sj")
        {
            count = 31;
        }
        else
        {
            count = int.Parse(textBox.text);
        }

        if (count == 30)
        {
            textBox.text = "sj";
        }
        else
        {
            textBox.text = (++count).ToString();
        }

        
    }

    private void decreaseCount(TextMeshProUGUI textBox)
    {
        int count;
        if (textBox.text == "sj")
        {
            count = 31;
        }
        else
        {
            count = int.Parse(textBox.text);
        }
        
        if (count > 0)
        {
            if (count == 32)
            {
                textBox.text = "sj";
            }
            else
            {
                textBox.text = (--count).ToString();
            }
        }
    }
    
    public void StartButton()
    {
        BasvampirCount = BasvampirCountText.text == "sj" ? 31 : int.Parse((BasvampirCountText.text));
        VampirCount = VampirCountText.text == "sj" ? 31 : int.Parse((VampirCountText.text));
        KoyluCount = KoyluCountText.text == "sj" ? 31 : int.Parse((KoyluCountText.text));
        DoktorCount = DoktorCountText.text == "sj" ? 31 : int.Parse((DoktorCountText.text));
        GozcuCount = GozcuCountText.text == "sj" ? 31 : int.Parse((GozcuCountText.text));
        SoytariCount = SoytariCountText.text == "sj" ? 31 : int.Parse((SoytariCountText.text));
        totalOyuncuCount = BasvampirCount + VampirCount + KoyluCount + DoktorCount + GozcuCount + SoytariCount;

        if (totalOyuncuCount >= 4) // Checking player count. If its lower than 3 the game does not start. (Bunu anlatmazsam hat�rlat ba�ka checklerde eklenebilir.)
        {
            GeneralMethod.FillOyuncuRoles(new List<int>{BasvampirCount, VampirCount, KoyluCount, DoktorCount, GozcuCount ,SoytariCount});
            SceneManager.LoadScene("NameScene");
        }
        else
        {
            ErrorMessage.gameObject.SetActive(true);
        }
            
    }
}