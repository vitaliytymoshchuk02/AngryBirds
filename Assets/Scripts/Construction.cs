using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Construction : MonoBehaviour
{
    private int _health = 5000;
    private Rigidbody2D _rigidbody;
    private float _minVelocity = 0.1f;
    private int _damage = 1000;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>())
        {
            Rigidbody2D rigidbodyCollisison = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 relativeVelocity = _rigidbody.velocity - rigidbodyCollisison.velocity;
            Debug.Log("sqrMagnitude:" + relativeVelocity.sqrMagnitude);

            if (relativeVelocity.sqrMagnitude > _minVelocity)
            {
                Hit(collision);
            }
        }
    }
    private void Hit(Collision2D collision)
    {
        _health -= _damage;

        if(_health <= 0)
        {
            Break();
        }
    }

    private void Break()
    {
        Destroy(gameObject);
    }
}
