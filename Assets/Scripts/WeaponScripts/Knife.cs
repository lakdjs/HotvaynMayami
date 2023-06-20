using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Knife : AWepon
{
    private void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.layer == 6)
       {
           Debug.Log("Enemy!");
          // Destroy(gameObject);
       }
       else if(other.gameObject.layer == 3)
       {
           Debug.Log("Other!");
            // Destroy(gameObject);
       }
   }
    public override void Fire()
    {
        throw new System.NotImplementedException();
    }
}
