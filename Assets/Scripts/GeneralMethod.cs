using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeneralMethod : MonoBehaviour
{
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

    public static void HandleNightEvents()
    {
        //Choosing vampires victim.
        Oyuncu victim = new Oyuncu();
        victim.voteCount = -1;
        foreach (var oyuncu in NameSceneController.oyuncuList)
        {
            if (victim.voteCount < oyuncu.voteCount)
            {
                victim = oyuncu;
            }
            else if (victim.voteCount == oyuncu.voteCount)
            {
                System.Random rnd = new System.Random();
                var randInt = rnd.Next(2);
                if (randInt == 1)
                    victim = oyuncu;
            }
        }
        
        //Checking if victim protected.
        if (!victim.IsProtected && victim.voteCount != 0)
        {
            victim.IsDead = true;
            DayScene.geceOlenler = victim.Name + Environment.NewLine;
        }
            
        
        //Setting isProdected and voteCount to defult
        foreach (var oyuncu in NameSceneController.oyuncuList)
        {
            oyuncu.IsProtected = false;
            oyuncu.voteCount = 0;
        }
    }

    public static int GetARandomAlivePlayersIndex()
    {
        int rndInt;
        System.Random rnd = new System.Random();
        while (true)
        {
            rndInt = rnd.Next(NameSceneController.oyuncuList.Count);
            if (!NameSceneController.oyuncuList[rndInt].IsDead && rndInt != StartNight.playerIndex)
            {
                break;
            }
        }

        return rndInt;
    }

    public static bool isThereWinner()
    {
        int aliveVampireCount = 0, aliveVillagerCount = 0;
        //Getting alive Vampires and Villagers count
        foreach (var oyuncu in NameSceneController.oyuncuList)
        {
            if (oyuncu.IsDead == false)
            {
                if (oyuncu.role.ToString() == "Vampir" || oyuncu.role.ToString() == "Basvampir")
                {
                    aliveVampireCount++;
                }
                else if (oyuncu.role.ToString() == "Koylu" || oyuncu.role.ToString() == "Doktor" ||
                         oyuncu.role.ToString() == "Gozcu")
                {
                    aliveVillagerCount++;
                }
            }
        }
        
        //Checking if the vampires win(is vampire count equals to villager count)
        if (aliveVampireCount >= aliveVillagerCount)
        {
            WinSceneManager.victoriousTeam = "Vampirler";
            return true;
        }
        //Checking if the village win(is vampire count equals to 0)
        if (aliveVampireCount == 0)
        {
            WinSceneManager.victoriousTeam = "Koy";
            return true;
        }

        return false;
    }

    public static string GetVampiresNames()
    {
        string Vampires = "";
        foreach (var oyuncu in NameSceneController.oyuncuList)
        {
            if (oyuncu.role.ToString() == "Basvampir")
            {
                Vampires += oyuncu.Name + ": (Basvampir)" + Environment.NewLine;
                break;
            }  
        }

        foreach (var oyuncu in NameSceneController.oyuncuList)
        {
            if (oyuncu.role.ToString() == "Vampir")
            {
                Vampires += oyuncu.Name + Environment.NewLine;
            }
        }
        return Vampires;
    }
    
}
