using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private AWepon _weapon;
    private PlayerWeaponController _playerWeaponController;
    private string _weaponInTrigger;
    private bool _isWeaponInTrigger;
    private void Start()
    {
        _isWeaponInTrigger = false;
        _playerWeaponController = FindObjectOfType<PlayerWeaponController>();
    }
    private void Update()
    {
        if (_playerWeaponController.InTrigger && _isWeaponInTrigger && Input.GetMouseButtonDown(1))
        {
            StartCoroutine("wait");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playerWeaponController.InTrigger = true;
            _isWeaponInTrigger = true;
            _weaponInTrigger = _weapon.Type.ToString();      
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playerWeaponController.InTrigger = false;
            _isWeaponInTrigger = false;
            _weaponInTrigger = AWepon.KNIFE;
        }
    }
    IEnumerator wait()
    {
        if(_playerWeaponController.CurrentWeapon != AWepon.KNIFE)
        {
            _playerWeaponController.DropWeapon(_playerWeaponController.CurrentWeapon);
        }
        yield return new WaitForSeconds(0.02f);     
            _playerWeaponController.CurrentWeapon = _weaponInTrigger;
            Destroy(gameObject);  
        //if(gameObject.GetComponent<WeaponManager>()._weapon.Type.ToString() == _weaponInTrigger)
        
    }
}
