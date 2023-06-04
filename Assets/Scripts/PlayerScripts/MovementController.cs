using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;

    private float _x, _y;
    public bool canMove = true;

    private Vector3 _mousePosition;
    private Vector3 _direct;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        _mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        _direct = _mousePosition - transform.position;
        _direct.Normalize();
        InputManager();
        LookAtPoint();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            MovementManager();
        }
    }
    public void InputManager()
    {
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");
    }
    public void MovementManager()
    {
        _rigidbody2D.velocity = new Vector2(_x * _speed, _y * _speed);
    }
    private void LookAtPoint()
    {
        float angle = Mathf.Atan2(_direct.y, _direct.x) * Mathf.Rad2Deg;
        _rigidbody2D.rotation = angle;
    }
}
