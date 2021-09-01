using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralMethod : MonoBehaviour
{

    public static List<Oyuncu> saldirilanlar;
    public static List<Oyuncu> korunanlar;
    public static List<Oyuncu> olenler;
    private static List<string> rolller = new List<string> {"Basvampir","Vampir","Koylu","Doktor","Gozcu" };
    private static List<string> oyuncuRoller = new List<string>();

    public static List<string> GetPlayersStatus()
    {
        string yasayanlarText = "Hayatta Olan Oyuncular:" + Environment.NewLine;
        string olenlerText = "Olen Oyuncular:" + Environment.NewLine;
        foreach (var player in NameSceneController.oyuncuList)
        {
            if (!player.IsDead)
            {
                yasayanlarText += player.Name + Environment.NewLine;
                
            }
            else
            {
                olenlerText += player.Name + Environment.NewLine;
            }
            
        }

        return new List<string>{yasayanlarText,olenlerText};
    }
    
    public static List<string> GetNames(List<Oyuncu> players)
    {
        List<string> playerNames = new List<string>();
        foreach (var player in players)
        {
            playerNames.Add(player.Name);
        }
        return playerNames;
    }

    public static void FillOyuncuRoles(List<int> roleCounts)
    {
        for (int j = 0; j < roleCounts.Count; j++)
        {
            for (int i = 0; i < roleCounts[j]; i++)
            {
                oyuncuRoller.Add(rolller[j]);
            }
        }
    }

    public static ParentRole GetARandomRole()
    {
        System.Random rnd = new System.Random();
        var randInt = rnd.Next(oyuncuRoller.Count);
        switch (oyuncuRoller[randInt])
        {
            case "Basvampir":
                oyuncuRoller.Remove("Basvampir");
                return new BasVampir();
            case "Vampir":
                oyuncuRoller.Remove("Vampir");
                return new Vampir();
            case "Koylu":
                oyuncuRoller.Remove("Koylu");
                return new Koylu();
            case "Doktor":
                oyuncuRoller.Remove("Doktor");
                return new Doktor();
            case "Gozcu":
                oyuncuRoller.Remove("Gozcu");
                return new Gozcu();
            default:
                return new ParentRole();
        }
    }

    public static Oyuncu GetPlayerByIndex(int i)
    {
        return NameSceneController.oyuncuList[i];
    }

    public static Oyuncu GetPlayerByName(string name)
    {
        var oyuncuNames = GetNames(NameSceneController.oyuncuList);
        for (int i = 0; i < oyuncuNames.Count; i++)
        {
            if (oyuncuNames[i] == name)
            {
                return GetPlayerByIndex(i);
            }
        }
        Debug.Log("Bez getre");
        return new Oyuncu();
    }
}
