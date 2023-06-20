using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float _hp;
    [SerializeField] private float _defense;
    [SerializeField] private Sprite _deadSprite;
    [SerializeField] private SpriteRenderer _sp;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private PlayerWeaponController _playerWC;
    [SerializeField] private PlayerAnimationController _playerAC;
    [SerializeField] private BoxCollider2D _playerBC2D;
    [SerializeField] private CircleCollider2D _playerCC2D;
    [SerializeField] private MovementController _playerMC;
    [SerializeField] private Rigidbody2D _playerRB;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _damage;
    [SerializeField] private AudioClip _death;
    [SerializeField] private Image _settings;
    private Collider2D _col;
    public float HP { get => _hp; }
    void Update()
    {
       // Debug.Log(_hp);
        if (_hp <= 0)
        {
            Debug.Log("вы умерли");
           _playerAnimator.enabled = false;
           _playerAC.enabled = false;
           _playerWC.enabled = false;
           _playerBC2D.enabled = false;
           _playerCC2D.enabled = false;
           _playerMC.enabled = false;
           _playerRB.simulated = false;
           _sp.sprite = _deadSprite;
            _source.PlayOneShot(_death);
            _settings.gameObject.SetActive(true);
        }
        if(_col is not null)
        {
            _source.PlayOneShot(_damage);
            _hp -= _col.GetComponent<Bullet>().Damage;
            Destroy(_col.gameObject);
        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            _col = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _col = null;
    }
}
