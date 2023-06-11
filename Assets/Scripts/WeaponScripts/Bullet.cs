using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update()
    {
        transform.Translate(new Vector2(0,_speed * Time.deltaTime));
        Destroy(gameObject, 1.5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6||collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }
   //private void OnTriggerEnter2D(Collider2D other)
   //{
   //    Debug.Log("Chtoto");
   //    if(other.gameObject.layer == 6)
   //    {
   //        Debug.Log("Enemy!");
   //        _col = other;
   //       // Destroy(gameObject);
   //    }
   //    else if(other.gameObject.layer == 3)
   //    {
   //        Debug.Log("Other!");
   //        Destroy(gameObject);
   //    }
   //}
}
