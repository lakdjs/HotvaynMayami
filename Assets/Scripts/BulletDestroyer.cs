using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    private Collider2D _col;
    private void Update()
    {
        if(_col!=null)
        {
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
