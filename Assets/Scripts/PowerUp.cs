using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
  public PowerUpSO powerUpSO;
  [SerializeField] private Bullet bullet;

  private void OnTriggerEnter2D(Collider2D collision) {
    Destroy(gameObject);
    if (collision.gameObject.tag == "Bullet") {
      Debug.Log(true);      
      // Debug.Log(bullet.shooter);      
      powerUpSO.ApplyEffect(bullet.shooter);
    } else {
      Debug.Log(false);      
      powerUpSO.ApplyEffect(collision.gameObject);
    }
  }
}
