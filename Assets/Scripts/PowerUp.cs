using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
  public PowerUpSO powerUpSO;
  [SerializeField] private Bullet bullet;

  private void OnCollisionEnter2D(Collision2D collision) {
    if (!collision.gameObject.CompareTag("Player")) return;
    powerUpSO.ApplyEffect(collision.gameObject);
    StartCoroutine(WaitForPowerUpTimeout(collision.gameObject));
    gameObject.transform.localScale = new Vector3(0, 0, 0);
  }
  
  IEnumerator WaitForPowerUpTimeout(GameObject player) {
    yield return new WaitForSeconds(powerUpSO.Duration);
    powerUpSO.ResetEffect(player, gameObject);
  }
}
