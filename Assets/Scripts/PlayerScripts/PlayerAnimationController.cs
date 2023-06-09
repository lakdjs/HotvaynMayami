using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] PlayerWeaponController _playerWeaponController;
    private bool _shoot;
    private int _weaponID = 0;
    public int WeaponID => _weaponID;
    private void Update()
    {
        WeaponAnimation(_playerWeaponController.CurrentWeapon);
        _animator.SetInteger("weapons", _weaponID);
    }
    void WeaponAnimation(string weapon)
    {
       switch(weapon)
       {
            case AWepon.KNIFE:
                _weaponID = 0;
                break;
            case AWepon.PISTOL:
                _weaponID = 1;
                break;
            case AWepon.RIFLE:
                _weaponID = 2;
                break;
        }
    }
}
