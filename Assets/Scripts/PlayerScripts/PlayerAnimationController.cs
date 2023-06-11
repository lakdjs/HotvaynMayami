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
        Debug.Log(_shoot);
        WeaponAnimation(_playerWeaponController.CurrentWeapon);
        _animator.SetInteger("weapons", _weaponID);
        AtttackAnimation();
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
    void AtttackAnimation()
    {
        _shoot = _playerWeaponController.Shoot;
        if (Input.GetMouseButtonDown(0))
        {
            switch (_weaponID)
            {
                case 0:
                    _animator.SetTrigger("attack");
                    break;
                case 1:
                    StartCoroutine("shooting",0.5);
                    break;
                default:
                    break;
            }
        }
        if(Input.GetMouseButton(0))
        {
            switch(_weaponID)
            {
                case 2:
                    StartCoroutine("shooting",0.1f);
                    break;
                default:
                    break;
            }
        }
    }
    IEnumerator shooting(float time)
    {
        _animator.SetTrigger("attack");

        yield return new WaitForSeconds(time);
    }
}
