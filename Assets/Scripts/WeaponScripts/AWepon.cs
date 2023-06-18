using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AWepon : MonoBehaviour
{
    public enum Weapons
    {
        Knife,
        Pistol,
        Rifle
    }
   
    [SerializeField] private AWepon.Weapons _weaponType;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bullet;
    public const string KNIFE = "Knife";
    public const string PISTOL = "Pistol";
    public const string RIFLE = "Rifle";
    public bool IsInTrigger { get; private set; }

    public AWepon.Weapons Type => _weaponType;
    public int Damage => _damage;
        
    public abstract void Fire();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IsInTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.tag == "Player")
        {
            IsInTrigger = false;
        }
    }
}
