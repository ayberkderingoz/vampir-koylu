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
    public static int BasvampirCount;
    public static int VampirCount;
    public static int KoyluCount;
    public static int DoktorCount;
    public static int GozcuCount;
    

    void Start()
    {
        
    }
    public void onPressIncreaseButton()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "ButtonBasvampirArtir")
        {
            increaseCount(BasvampirCountText);
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
        
        
    }

    public void onPressDecreaseButton()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "ButtonBasvampirAzalt")
        {
            decreaseCount(BasvampirCountText);
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
        SceneManager.LoadScene("NameScene");
    }
}