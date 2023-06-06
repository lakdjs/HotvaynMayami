using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsManager : MonoBehaviour
{
    public string CurrentWeapon;
    public bool InTrigger;
    private string _knife = Weapons.WeaponType.Knife.ToString();
    private void Update()
    {
        WeaponManager();
    }
    void WeaponManager()
    {
        if(Input.GetMouseButtonDown(1)&&!InTrigger)
        {
            DropWeapon(CurrentWeapon);
        }
    }
    public void DropWeapon(string weaponName)
    {  
        if (CurrentWeapon != _knife)
        {
            Instantiate(Resources.Load("Prefabs/Items/" + weaponName), transform.position, Quaternion.identity);
            if(!InTrigger)
                CurrentWeapon = _knife;
            
        }
        else
        {
            Debug.Log("Нет оружия!");
        }
    }
}
