using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VoteScreenManager : MonoBehaviour
{
    public GameObject buttonPrefab;
    public static Oyuncu lastClicked;
    private GameObject gameobj;
    public Button skipButton;
    public Button cancelButton;
    // Start is called before the first frame update
    void Start()
    {
        gameobj = GameObject.Find("Content");
        cancelButton.onClick.AddListener(onCancelButtonClickEvent);
        for (int i = 0; i < ButtonInteraction.totalOyuncuCount; i++)
        {
            GameObject button = (GameObject)Instantiate(buttonPrefab, gameobj.transform, false);
            button.transform.GetChild(0).GetComponent<TMP_Text>().text = NameSceneController.oyuncuList[i].Name;
            button.GetComponent<Button>().onClick.AddListener(onClickEvent);
        }

        HideDeadPlayers();
        GameObject.Find("ScrollArea").GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
        skipButton.enabled = false;
        skipButton.onClick.AddListener(onSkipButtonClickEvent);
    }

    private void onClickEvent()
    {
        lastClicked = GeneralMethod.GetPlayerByName(EventSystem.current.currentSelectedGameObject.transform.GetChild(0)
            .GetComponent<TMP_Text>().text);
        //Debug.Log(lastClicked.Name);
        skipButton.enabled = true;
    }
    // Update is called once per frame
    private void onSkipButtonClickEvent()
    {
        lastClicked.IsDead = true;
        if (lastClicked.role.ToString() == "Soytari")
        {
            ((Soytari) lastClicked.role).isHanged = true;
            ((Soytari) lastClicked.role).shouldKillSomeone = true;
            GeneralMethod.isJesterKilled = false;
            WinSceneManager.soytariWin = true;
        }
        StartNight.playerIndex = 0;
        if (GeneralMethod.isThereWinner())
        {
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            SceneManager.LoadScene("StartNightScene");
        }
    }

    private void onCancelButtonClickEvent()
    {
        SceneManager.LoadScene("StartDayScene");
    }

    private void HideDeadPlayers()
    {
        for (int i = 0; i < NameSceneController.oyuncuList.Count; i++)
        {
            var playerButton = GameObject.Find("Content").transform.GetChild(i).GetComponent<Button>();
            if (NameSceneController.oyuncuList[i].IsDead)
            {
                playerButton.gameObject.SetActive(false);
            }
            
        }
    }
}
