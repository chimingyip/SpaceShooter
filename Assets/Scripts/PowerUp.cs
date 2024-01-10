using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
  public PowerUpSO powerUpSO;
  [SerializeField] private Bullet bullet;
  
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (!collision.gameObject.CompareTag("Player")) return;
    SoundEffectsManager.instance.PlayPowerUpPickUpSound();
    powerUpSO.ApplyEffect(collision.gameObject);
    UIManager.instance.TogglePowerUpIcons(true);
    StartCoroutine(WaitForPowerUpTimeout(collision.gameObject));
    gameObject.transform.localScale = new Vector3(0, 0, 0);
  }

  IEnumerator WaitForPowerUpTimeout(GameObject player)
  {
    yield return new WaitForSeconds(powerUpSO.Duration);
    powerUpSO.ResetEffect(player, gameObject);
    UIManager.instance.TogglePowerUpIcons(false);
  }
}