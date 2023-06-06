using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerWeaponsManager _playerWeaponsManager;
    private int _weaponID = 0;
    private void Update()
    {
        WeaponAnimation(_playerWeaponsManager.CurrentWeapon);
        _animator.SetInteger("weapons", _weaponID);
    }
    void WeaponAnimation(string weapon)
    {
        switch(weapon)
        {
            case Weapons.KNIFE:
                _weaponID = 0;
                break;
            case Weapons.PISTOL:
                _weaponID = 1;  
                break;
            case Weapons.RIFLE:
                _weaponID = 2;
                break;
        }
    }
}
