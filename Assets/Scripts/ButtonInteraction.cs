using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI BasvampirCountText;
    [SerializeField] private TextMeshProUGUI VampirCountText;
    [SerializeField] private TextMeshProUGUI KoyluCountText;
    [SerializeField] private TextMeshProUGUI DoktorCountText;
    [SerializeField] private TextMeshProUGUI GozcuCountText;
    

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
}