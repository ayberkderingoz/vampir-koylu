using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralMethod : MonoBehaviour
{
    public static List<string> GetNames(List<ParentRole> players)
    {
        List<string> playerNames = new List<string>();
        foreach (var player in players)
        {
            playerNames.Add(player.Name);
        }
        return playerNames;
    }
}
