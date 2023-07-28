using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour {
  [Header("Firing Variables")]
  [SerializeField] private Transform centralFirePoint;
  [SerializeField] private Transform leftFirePoint;
  [SerializeField] private Transform rightFirePoint;

  public enum FireMode {
    Single, 
    Double, 
    Triple
  }
  public FireMode currentFireMode = FireMode.Single;
  private bool isFiring = false;

  [Header("Bullet Data")]
  [SerializeField] private GameObject bulletPrefab;
  [SerializeField] private float bulletForce = 20f;

  [Header("Cooldowns")]
  [SerializeField] private float cooldownAmount = 0.2f;
  private BulletCooldownTimer bulletCooldownTimer;

  [Header("Power ups")]
  public bool isPoweredUp = false;
  public float powerUpTimer;

  private void Awake() {
    bulletCooldownTimer = gameObject.AddComponent<BulletCooldownTimer>();
  }

  private void FixedUpdate() {
    if (isFiring) {
      if (!bulletCooldownTimer.CooldownComplete) return;
      bulletCooldownTimer.StartCooldown(cooldownAmount);

      if (isPoweredUp) {
        powerUpTimer -= Time.deltaTime;

        if (powerUpTimer <= 0) {
          currentFireMode = FireMode.Single;
          powerUpTimer = 0;
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
