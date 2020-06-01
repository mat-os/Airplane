using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    [SerializeField] private int damage;

    private float timer;

    private void OnEnable()
    {
        timer = 0;
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * speed;
        timer += Time.deltaTime;
        
        if (timer >= lifetime)
        {
            ObjectPool.Instance.PoolObject(gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(typeof(IDamageable), out Component damageble))
        {
            IDamageable hit = (IDamageable) other.gameObject.GetComponent(typeof(IDamageable)); 
            hit.TakeDamage(damage);
        }
    }
}
