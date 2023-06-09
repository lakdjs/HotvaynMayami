using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] PlayerAnimationController _playerAnimationController;
    [SerializeField]private string _currentWeapon;
    [SerializeField] Transform _firePoint;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _shooting;
    [SerializeField] private AudioClip _swinging;
    private bool _inTrigger = false, _shoot = true;
    private string _weaponInTrigger;
    private bool _isWeaponInTrigger;
    
    private Collider2D _col;

    public string CurrentWeapon => _currentWeapon;
    public bool InTrigger => _inTrigger;
    public bool Shoot => _shoot;
    private void Start()
    {
        _isWeaponInTrigger = false;
    }
    private void Update()
    {
        //Debug.Log(_shoot);
        AttackManager(_playerAnimationController.WeaponID);
        WeaponManager();
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
            Debug.Log("������ �������� ���!");
        }
    }
   void AttackManager(int id)
    {
        if (Input.GetMouseButtonDown(0) && _shoot)
            {
            switch (id)
            {
                case 0:
                    _animator.SetTrigger("attack");
                    break;
                case 1:
                    StartCoroutine("shooting", 0.5f);
                    break;
                default:
                    break;
            }
            }
            if (Input.GetMouseButton(0) && _shoot)
            {
            switch (id)
            {
                case 2:
                    StartCoroutine("shooting", 0.1f);
                    break;
                default:
                    break;
            }
        }
    }
    public void KnifeHit(float time)
    {
        StartCoroutine("knife",time);
    }
    IEnumerator shooting(float time)
    {
        Instantiate(Resources.Load("Prefabs/Items/" + CurrentWeapon + "_bullet"),_firePoint.position,_firePoint.rotation);
        _animator.SetTrigger("attack");
        _shoot = false;
        _source.PlayOneShot(_shooting);
        yield return new WaitForSeconds(time);
        _shoot = true;
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
    IEnumerator knife(float time)
    {
        _source.PlayOneShot(_swinging);
        _firePoint.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        _firePoint.gameObject.SetActive(false);
    }
}
