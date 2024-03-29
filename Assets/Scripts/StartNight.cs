using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartNight : MonoBehaviour
{
    public static int playerIndex = 0;
    [SerializeField] private TMP_Text geceText;

    private void Start()
    {
        if (NameSceneController.oyuncuList[playerIndex].IsDead && 
            (NameSceneController.oyuncuList[playerIndex].role.ToString() != "Soytari" || 
             (NameSceneController.oyuncuList[playerIndex].role.ToString() == "Soytari" &&
              ((Soytari)(NameSceneController.oyuncuList[playerIndex].role)).shouldKillSomeone == false)))
        {
            playerIndex++;
            SceneManager.LoadScene(playerIndex < NameSceneController.oyuncuList.Count
                ? "StartNightScene"
                : "StartDayScene");
        }
        else
        {
            geceText.text = $"Telefonu {NameSceneController.oyuncuList[playerIndex].Name} adli oyuncuya verin.";
            GameObject.Find("GeceButton").GetComponent<Button>().onClick.AddListener(onPressGeceButton);   
        }
    }

    private void onPressGeceButton()
    {
        SceneManager.LoadScene("Test");
    }
}
