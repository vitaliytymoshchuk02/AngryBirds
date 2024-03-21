using System;
using Unity.VisualScripting;
using UnityEngine;
public class Pig : MonoBehaviour
{
    [SerializeField] GameObject _damageTextPrefab10000;
    [SerializeField] GameObject _damageTextPrefab5000;
    private Rigidbody2D _rigidbody;
    private int _health = 20000;
    private float _minVelocity = 0.1f;

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
        switch (collision.gameObject.tag)
        {
            case "Player": Damage(10000); break;
            case "Construction": Damage(5000); break;
        }
    }

    void Damage(int damage)
    {
        _health -= damage;
        ShowDamage(damage);

        if(_health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

    void ShowDamage(int damage)
    {
        GameObject damageText;
        if (damage > 5000)
        {
            damageText = Instantiate(_damageTextPrefab10000, null);
        }
        else
        {
            damageText = Instantiate(_damageTextPrefab5000, null);
        }
        damageText.transform.position = transform.position;
    }
}
