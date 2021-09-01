using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;

public class Oyuncu
{
    public bool IsDead { get; set; }
    public bool IsProtected { get; set; }
    
    public string Name { get; set; }

    public ParentRole role { get; set; }

    public Oyuncu()
    {
        IsDead = false;
        IsProtected = false;
    }
}

public class ParentRole
{
    public string RoleType { get; set; } 
    public virtual void StartNightEvent()
    {
        Debug.Log("Type atamasi yapilamadi");
    }
}
public class BasVampir : ParentRole
{
    public BasVampir()
    {
        RoleType = "Kotu";
    }

    public override void StartNightEvent()
    {
        Debug.Log("Basvampir" + RoleType);
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

    public override void StartNightEvent()
    {
        Debug.Log("Vampir "+ RoleType);
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
    
    public override void StartNightEvent()
    {
        Debug.Log("Koylu "+ RoleType);
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
    
    public override void StartNightEvent()
    {
        Debug.Log("Doktor "+ RoleType);
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
    
    public override void StartNightEvent()
    {
        Debug.Log("Gozcu "+ RoleType);
    }
    public override string ToString()
    {
        return "Gozcu";
    }
} 

