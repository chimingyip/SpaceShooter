using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private int lives = 4;

    private void OnTriggerEnter2D(Collider2D collision) {
        // if we have collided with an enemy
        // destroy the enemy game object and remove a player life
        if (collision.gameObject.tag == "Enemy") {
            Destroy(collision.gameObject);
            LoseLife();
        }
        Destroy(gameObject);
    }

    private void LoseLife() { 
        lives--;
    }
}
