using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerWeaponController : MonoBehaviour
{
    public string CurrentWeapon;
    public bool InTrigger;
    public bool IsArmed;
    private void Update()
    {
        if(CurrentWeapon == AWepon.KNIFE)
        {
            IsArmed = false;
        }
        else
        {
            IsArmed = true;
        }
        WeaponManager();
        Debug.Log(CurrentWeapon);
    }
    void WeaponManager()
    {
        if(Input.GetMouseButtonDown(1)&&!InTrigger&&IsArmed)
        {
            DropWeapon(CurrentWeapon);
        }
    }
    public void DropWeapon(string weapon)
    {
        if (IsArmed)
        {
            Instantiate(Resources.Load("Prefabs/Items/" + weapon), transform.position, Quaternion.identity);
            if(!InTrigger)
            {
                CurrentWeapon = AWepon.KNIFE;
            }
        }
        else
        {
            Debug.Log("Нельзя выкинуть нож!");
        }
    }
}
