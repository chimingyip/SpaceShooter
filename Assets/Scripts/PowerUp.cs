using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
  public GameObject enemyBullet;
  public GameObject player;

  private ShootBullets playerShooting;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    Debug.Log("Hit powerup");
    // ** Set up tags if enemies end up needing to shoot and could potentially hit the powerup
    // if (collision.gameObject.tag == "enemy")
    // {
    //     Physics2D.IgnoreCollision(enemyBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    // }
    playerShooting = player.GetComponent<ShootBullets>();
    playerShooting.currentFireMode = ShootBullets.FireMode.Double;
    playerShooting.isPoweredUp = true;
    playerShooting.powerUpTimer = 0.3f;
    Destroy(gameObject);
  }
}
