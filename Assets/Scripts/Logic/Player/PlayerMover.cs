using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float upForce;
    [SerializeField] private float gravityForce;

    private Vector2 _velocity;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _velocity = _rb.velocity;
        _velocity.x = horizontalSpeed;

        if (Input.GetKey(KeyCode.Space))
        {
            _velocity.y += upForce;
        }

        else
        {
            _velocity.y -= gravityForce;
        }

        _rb.velocity = _velocity;
    }
}
