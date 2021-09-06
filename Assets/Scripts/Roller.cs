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
        RoleType = "Kotu";
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
        RoleType = "Kotu";
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
    public Doktor()
    {
        RoleType = "iyi";
    }
    
    public override bool StartNightEvent(Oyuncu hedef)
    {
        // Debug.Log("Doktor "+ RoleType);
        hedef.IsProtected = true;
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
        else
            GameObject.Find("infoText").GetComponent<TMP_Text>().color = Color.red;
        GameObject.Find("infoText").GetComponent<TMP_Text>().text = $"{hedef.Name} adli oyuncu {hedef.role.RoleType}";
        //Debug.Log("Gozcu "+ RoleType);
        return true;
    }
    public override string ToString()
    {
        return "Gozcu";
    }
} 

