using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour {
  public Transform centralFirePoint;
  public GameObject bulletPrefab;
  public float bulletForce = 20f;
  protected BulletCooldownTimer bulletCooldownTimer;
  private bool isFiring = false;

  private void Awake() {
    bulletCooldownTimer = gameObject.AddComponent<BulletCooldownTimer>();
  }

  private void FixedUpdate() {
    if (isFiring) {
      if (!bulletCooldownTimer.CooldownComplete) return;
      bulletCooldownTimer.StartCooldown();

      GameObject bullet = Instantiate(bulletPrefab, centralFirePoint.position, centralFirePoint.rotation);
      Rigidbody2D centralRb = bullet.GetComponent<Rigidbody2D>();
      centralRb.AddForce(centralFirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
  }

  private void OnFire() {
    isFiring = !isFiring;
  }
}
