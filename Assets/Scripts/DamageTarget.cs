using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTarget : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;

    public void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            Destroy(gameObject);      
        }
    }
}
