using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
public enum WeaponType
    {
        Knife,
        Pistol,
        Rifle
    }
    public const string KNIFE = "Knife";
    public const string PISTOL = "Pistol";
    public const string RIFLE = "Rifle";
    public WeaponType weaponType;
}
