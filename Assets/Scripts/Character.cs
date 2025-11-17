using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// character class for chapter 5 - classes, structs, and oop
/// </summary>
public class Character
{
    public string name;
    public int experience;

    // constructor
    public Character(string name, int experience)
    {
        this.name = name;
        this.experience = experience;
    }

    // virtual method for printing stats
    public virtual void PrintStatsInfo()
    {
        Debug.LogFormat("Character: {0} - {1} XP", name, experience);
    }
}

/// <summary>
/// weapon struct for chapter 5
/// </summary>
public struct Weapon
{
    public string name;
    public int damage;

    // constructor
    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    // method for printing weapon info
    public void PrintWeaponInfo()
    {
        Debug.LogFormat("Weapon: {0} - {1} DMG", name, damage);
    }
}

/// <summary>
/// paladin child class inheriting from character
/// </summary>
public class Paladin : Character
{
    public Weapon weapon;

    // constructor calling base constructor
    public Paladin(string name, int experience, Weapon weapon) : base(name, experience)
    {
        this.weapon = weapon;
    }

    // override base class method
    public override void PrintStatsInfo()
    {
        Debug.LogFormat("Paladin: {0} - {1} XP, Weapon: {2}", name, experience, weapon.name);
    }
}

