using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Weapon
{
    public string WeaponName;
    public int Cost;

    public Levels LevelType;
    public GameObject Prefab;
}

public static class WeaponValues
{

    public static int WeaponSelect;
    public static Weapon CurrentWeapon;

    public static Weapon C4;

    public static Weapon ToonBomb;

}
