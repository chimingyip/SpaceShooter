using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject shooter;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private float explosionDestroyTime;
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision) {

        // if (collision.gameObject == shooter) {
        //     return;
        // }
        // GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        DamageTarget target = collision.GetComponent<DamageTarget>();
        // Debug.Log(collision);

        if (target) {
            target.TakeDamage(damage);
        }
        // Destroy(effect, explosionDestroyTime);
        Destroy(gameObject);
    }
}
