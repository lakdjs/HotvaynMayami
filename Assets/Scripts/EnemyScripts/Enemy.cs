using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AWepon _weaponType;
    [SerializeField] private float _hp;
    [SerializeField] private int _defense;
    [SerializeField] private float _speed;
    private Collider2D _col;
    void Update()
    {
        Debug.Log(_hp);
        if (_hp <= 0)
        {
            Debug.Log("�� ������");
            Destroy(gameObject);
        }
        if (_col is not null)
        {
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
