using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce = 5f;
    [SerializeField] private float cooldownAmount = 1f;
    [SerializeField] private GameObject bulletPrefab;


    private BulletCooldownTimer bulletCooldownTimer;

    private void Awake() {
        bulletCooldownTimer = gameObject.AddComponent<BulletCooldownTimer>();
    }

    private void FixedUpdate() {
        if (!bulletCooldownTimer.CooldownComplete) return;
        bulletCooldownTimer.StartCooldown(cooldownAmount);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
