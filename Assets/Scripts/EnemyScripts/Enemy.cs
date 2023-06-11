using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AWepon _weaponType;
    [SerializeField] private int _health;
    [SerializeField] private int _defense;
    [SerializeField] private float _speed;
}
