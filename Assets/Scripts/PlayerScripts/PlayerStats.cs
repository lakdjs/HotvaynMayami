using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
[SerializeField] private float _hp;
[SerializeField] private float _defense;
    private Collider2D _col;
    void Update()
    {
        Debug.Log(_hp);
        if (_hp <= 0)
        {
            Debug.Log("вы умерли");
            gameObject.SetActive(false);
        }
        if(_col is not null)
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
