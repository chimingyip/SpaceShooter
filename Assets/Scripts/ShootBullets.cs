using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour {
  public Transform centralFirePoint, leftFirePoint, rightFirePoint;
  public enum FireMode {
    Single, 
    Double, 
    Triple
  }
  public FireMode currentFireMode = FireMode.Single;
  public GameObject bulletPrefab;
  public float bulletForce = 20f;
  public bool isPoweredUp = false;
  public float powerUpTimer;
  protected BulletCooldownTimer bulletCooldownTimer;
  private bool isFiring = false;

  private void Awake() {
    bulletCooldownTimer = gameObject.AddComponent<BulletCooldownTimer>();
  }

  private void FixedUpdate() {
    if (isFiring) {
      if (!bulletCooldownTimer.CooldownComplete) return;
      bulletCooldownTimer.StartCooldown();

      if (isPoweredUp) {
        powerUpTimer -= Time.deltaTime;

        if (powerUpTimer <= 0) {
          currentFireMode = FireMode.Single;
          // powerUpTimer = 0;
          isPoweredUp = false;
        }
      }

      switch (currentFireMode) {
        case FireMode.Single:
          GameObject bullet = Instantiate(bulletPrefab, centralFirePoint.position, centralFirePoint.rotation);
          Rigidbody2D centralRb = bullet.GetComponent<Rigidbody2D>();
          centralRb.AddForce(centralFirePoint.up * bulletForce, ForceMode2D.Impulse);
          break;
        case FireMode.Double:
          GameObject rightBullet = Instantiate(bulletPrefab, rightFirePoint.position, rightFirePoint.rotation);
					Rigidbody2D rightRb = rightBullet.GetComponent<Rigidbody2D>();
					rightRb.AddForce(rightFirePoint.up * bulletForce, ForceMode2D.Impulse);
					GameObject leftBullet = Instantiate(bulletPrefab, leftFirePoint.position, leftFirePoint.rotation);
					Rigidbody2D leftRb = leftBullet.GetComponent<Rigidbody2D>();
					leftRb.AddForce(leftFirePoint.up * bulletForce, ForceMode2D.Impulse);
          break;
      }
    }
  }

  private void OnFire() {
    isFiring = !isFiring;
  }
}
