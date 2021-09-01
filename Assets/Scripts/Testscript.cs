using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Testscript : MonoBehaviour
{
    private GameObject gameobj;

    public GameObject buttonPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        gameobj = GameObject.Find("Content");
        
        
        for (int i = 0; i < ButtonInteraction.totalOyuncuCount; i++)
        {
            GameObject button = (GameObject)Instantiate(buttonPrefab);
            button.transform.SetParent(gameobj.transform);
            button.transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 50f;
            button.transform.GetChild(0).GetComponent<TMP_Text>().text = NameSceneController.oyuncuList[i].Name;
            button.GetComponent<Button>().onClick.AddListener(onClickEvent);
        }

        GameObject.Find("ScrollArea").GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
    }

    // Update is called once per frame
    public void onClickEvent()
    {
        if (StartNight.playerIndex == NameSceneController.oyuncuList.Count)
        {
            StartNight.playerIndex = 0;
            SceneManager.LoadScene("StartDayScene");
        }
        else
            SceneManager.LoadScene("StartNightScene");
        //Debug.Log(GeneralMethod.GetPlayerByName(EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TMP_Text>().text).role.ToString());
    }
}
