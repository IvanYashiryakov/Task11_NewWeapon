using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private float _lifeTime = 1;
    private Vector2 direction;

    private void Start()
    {
        direction = new Vector2(-1, Random.Range(-0.03f, 0.03f));
        Destroy(gameObject, _lifeTime);
    }

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * direction, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
