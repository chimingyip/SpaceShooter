using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private float explosionDestroyTime;
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision) {
        // GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        DamageTarget target = collision.GetComponent<DamageTarget>();

        if (target) {
            target.TakeDamage(damage);
        }
        // Destroy(effect, explosionDestroyTime);
        Destroy(gameObject);
    }
}
