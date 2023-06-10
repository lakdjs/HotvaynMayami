using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField]private string _currentWeapon;
    private bool _inTrigger;
    private string _weaponInTrigger;
    private bool _isWeaponInTrigger;
    private Collider2D _col;
    public string CurrentWeapon => _currentWeapon;
    public bool InTrigger => _inTrigger;
    private void Start()
    {
        _isWeaponInTrigger = false;
    }
    private void Update()
    {
        WeaponManager();
        Debug.Log(CurrentWeapon);
        if (_inTrigger && _isWeaponInTrigger && Input.GetMouseButtonDown(1))
        {
            StartCoroutine("wait");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            _inTrigger = true;
            _isWeaponInTrigger = true;
            _col = collision;
            _weaponInTrigger = collision.GetComponent<AWepon>().Type.ToString();
        }  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            _col = null;
            _inTrigger = false;
            _isWeaponInTrigger = false;
            _weaponInTrigger = AWepon.KNIFE;
        }
    }
    void WeaponManager()
    {
        if(Input.GetMouseButtonDown(1)&&!_inTrigger)
        {
            DropWeapon(_currentWeapon);
        }
    }
    public void DropWeapon(string weapon)
    {
        if (_currentWeapon != AWepon.KNIFE)
        {
            Instantiate(Resources.Load("Prefabs/Items/" + weapon), transform.position, Quaternion.identity);
            if(!_inTrigger)
            {
                _currentWeapon = AWepon.KNIFE;
            }
        }
        else
        {
            Debug.Log("Нельзя выкинуть нож!");
        }
    }
    IEnumerator wait()
    {
        if (_currentWeapon != AWepon.KNIFE)
        {
            DropWeapon(_currentWeapon);
        }
        yield return new WaitForSeconds(0.02f);
        _currentWeapon = _weaponInTrigger;
        Destroy(_col.gameObject);
    }
}
