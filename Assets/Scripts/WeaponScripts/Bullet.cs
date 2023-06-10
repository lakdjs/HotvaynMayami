using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update()
    {
        transform.Translate(new Vector2(0,_speed * Time.deltaTime));
        Destroy(gameObject, 2.5f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy")
        {
            Debug.Log("Enemy!");
            Destroy(gameObject);
        }
        else if(other.tag == "other")
        {
            Debug.Log("Other!");
            Destroy(gameObject);
        }
    }
}
