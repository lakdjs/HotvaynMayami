using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _transforms;
    public int quantity;
    void Update()
    {
        if(quantity<=0)
        {
            for(int i = 0; i < 4; i ++)
            {
                Instantiate(Resources.Load("Prefabs/Enemy"), _transforms[i].position, _transforms[i].rotation);
                quantity++;
            }     
        }
    }
}
