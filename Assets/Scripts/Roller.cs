using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;

public abstract class ParentRole
{
    public bool IsDead { get; set; }
    public bool IsProtected { get; set; }
    public string RoleType { get; set; }
    public string Name { get; set; }

    public ParentRole()
    {
        IsDead = false;
        IsProtected = false;
        RoleType = "bisiler na man";
    }

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
        
    }
} 

