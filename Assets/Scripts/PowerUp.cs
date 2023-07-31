using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
  public PowerUpSO powerUpSO;
  [SerializeField] private Bullet bullet;

  private void OnCollisionEnter2D(Collision2D collision) {
    // If you want to try and get shooting to activate powerups working, remember to turn on powerup-bullet collisions in the collision matrix
    if (collision.gameObject.tag == "Bullet") {
      Debug.Log(true);      
      // Debug.Log(bullet.shooter);      
      powerUpSO.ApplyEffect(bullet.shooter);
    } else {
      Debug.Log(false);      
      powerUpSO.ApplyEffect(collision.gameObject);
    }
        Destroy(gameObject);

  }
}
