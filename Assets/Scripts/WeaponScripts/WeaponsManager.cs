using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public Weapons.WeaponType _weapons;
    private PlayerWeaponsManager _playerWeaponsManager;
    private void Start()
    {
        _playerWeaponsManager = FindObjectOfType<PlayerWeaponsManager>();
    }
    private void Update()
    {
         
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<PlayerWeaponsManager>().InTrigger = true;
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine("wait");
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<PlayerWeaponsManager>().InTrigger = false;
        }
    }


    IEnumerator wait()
    {
        if (_playerWeaponsManager.CurrentWeapon != Weapons.KNIFE)
        {
            _playerWeaponsManager.DropWeapon(_playerWeaponsManager.CurrentWeapon);
        }
        yield return new WaitForSeconds(0.02f);
        _playerWeaponsManager.CurrentWeapon = _weapons.ToString();
        Destroy(gameObject);
    }
}
