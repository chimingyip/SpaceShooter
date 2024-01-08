using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTarget : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    private bool isDestroyed = false;

    public void TakeDamage(int damage) {
        if (isDestroyed) return;
        
        health -= damage;

        if (health <= 0) {
            if (gameObject.CompareTag("Enemy"))
            {
                ScoreManager.instance.UpdateScore(1);
            }
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
