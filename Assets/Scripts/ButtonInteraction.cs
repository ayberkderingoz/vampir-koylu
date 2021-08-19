using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameObject textBox;
    private int n;

    void Start()
    {
        n = 0;
        
    }

    public void onPressButton()
    {
        updateText(n);
    }

    private void updateText(int n)
    {
        text.GetComponent<Text>().text = n.ToString();
    }

    private void increaseCount(GameObject textBox)
    {
        int count;
        count = Int32.Parse(textBox.gameObject.GetComponent<Text>().text);
    }
}