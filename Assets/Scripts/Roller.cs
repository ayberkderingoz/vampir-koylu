using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using TMPro;
using UnityEngine;

public class Oyuncu
{
    public bool IsDead { get; set; }
    public bool IsProtected { get; set; }
    public int voteCount { get; set; }  
    public string Name { get; set; }

    public ParentRole role { get; set; }

    public Oyuncu()
    {
        IsDead = false;
        IsProtected = false;
        voteCount = 0;
    }
}

public class ParentRole
{

    public string RoleType { get; set; } 
    public virtual bool StartNightEvent(Oyuncu oyuncu)
    {
        Debug.Log("Type atamasi yapilamadi");
        return true;
    }
}
public class BasVampir : ParentRole
{
    public BasVampir()
    {
        RoleType = "kotu";
    }

    public override bool StartNightEvent(Oyuncu hedef)
    {
        //Debug.Log("Basvampir" + RoleType);
        hedef.voteCount += 2;
        return true;
    }

    public override string ToString()
    {
        return "Basvampir";
    }
} 
public class Vampir : ParentRole
{
    public Vampir()
    {
        RoleType = "kotu";
    }

    public override bool StartNightEvent(Oyuncu hedef)
    {
        //Debug.Log("Vampir "+ RoleType);
        hedef.voteCount++;
        return true;
    }
    public override string ToString()
    {
        return "Vampir";
    }
} 
public class Koylu : ParentRole
{
    public Koylu()
    {
        RoleType = "iyi";
    }
    
    public override bool StartNightEvent(Oyuncu hedef)
    {
        Debug.Log(hedef.Name);
        Debug.Log(GeneralMethod.GetPlayerByIndex(Testscript.randInt).Name);
        if (hedef.Name == GeneralMethod.GetPlayerByIndex(Testscript.randInt).Name)
        {
            return true;
        }
        return false;
        //Debug.Log("Koylu "+ RoleType);
    }
    public override string ToString()
    {
        return "Koylu";
    }
} 
public class Doktor : ParentRole
{
    public int selfProtect = 1;
    public Oyuncu lastProtected;
    public Doktor()
    {
        RoleType = "iyi";
    }


    public override bool StartNightEvent(Oyuncu hedef)
    {
        // Debug.Log("Doktor "+ RoleType);
        hedef.IsProtected = true;
        if (hedef == NameSceneController.oyuncuList[StartNight.playerIndex])
        {
            if (selfProtect >0)
            {
                selfProtect--;
            }
        }

        lastProtected = hedef;
        return true;
    }
    public override string ToString()
    {
        return "Doktor";
    }
}
public class Gozcu : ParentRole
{
    public Gozcu()
    {
        RoleType = "iyi";
    }
    
    public override bool StartNightEvent(Oyuncu hedef)
    {
        if (hedef.role.RoleType == "iyi")
            GameObject.Find("infoText").GetComponent<TMP_Text>().color = Color.green;
        else if (hedef.role.RoleType == "kotu")
            GameObject.Find("infoText").GetComponent<TMP_Text>().color = Color.red;
        else if (hedef.role.RoleType == "cok kotu")
            GameObject.Find("infoText").GetComponent<TMP_Text>().color = Color.magenta;
        GameObject.Find("infoText").GetComponent<TMP_Text>().text = $"{hedef.Name} adli oyuncu {hedef.role.RoleType}";
        //Debug.Log("Gozcu "+ RoleType);
        return true;
    }
    public override string ToString()
    {
        return "Gozcu";
    }
}

public class Soytari : ParentRole
{
    public bool shouldKillSomeone;
    public bool isHanged;
    public Oyuncu victim;
    public Soytari()
    {
        isHanged = false;
        shouldKillSomeone = false;
        RoleType = "kotu";
    }
    public override bool StartNightEvent(Oyuncu hedef)
    {
        if (!NameSceneController.oyuncuList[StartNight.playerIndex].IsDead)
        {
            Debug.Log(hedef.Name);
            Debug.Log(GeneralMethod.GetPlayerByIndex(Testscript.randInt).Name);
            if (hedef.Name == GeneralMethod.GetPlayerByIndex(Testscript.randInt).Name)
            {
                return true;
            }

            return false;
        }
        if (((Soytari) NameSceneController.oyuncuList[StartNight.playerIndex].role).shouldKillSomeone)
        {
            victim = hedef;
        }
        return true;
        //Debug.Log("Koylu "+ RoleType);
    }
    public override string ToString()
    {
        return "Soytari";
    }
}

public class SeriKatil : ParentRole
{
    public Oyuncu victim;
    public SeriKatil()
    {
        RoleType = "cok kotu";
    }

    public override bool StartNightEvent(Oyuncu hedef)
    {
        victim = hedef;
        return true;
    }
    public override string ToString()
    {
        return "Seri Katil";
    }
} 
