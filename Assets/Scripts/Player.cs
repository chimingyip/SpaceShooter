using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  public static Player instance { get; private set; }

  public GameObject explosionPrefab;
  public GameObject gameOverScreen;

  [SerializeField] private float moveSpeed = 1f;
  [SerializeField] private float rightMoveBoundary = 1f;
  [SerializeField] private float leftMoveBoundary = -1f;

  public int lives = 4;

  private Vector2 moveInput;

  private void Start() {
    if (instance == null) {
      instance = this;
    }
  }

  private void FixedUpdate() {
    PlayerMovementBoundaries();
    transform.Translate(moveInput * moveSpeed * Time.deltaTime);
  }

  private void OnMove(InputValue value) {
    moveInput = value.Get<Vector2>();
  }

  private void PlayerMovementBoundaries() {
    float xMovementClamp = Mathf.Clamp(transform.position.x, leftMoveBoundary, rightMoveBoundary);
    Vector2 limitPlayerMovement = new Vector2(xMovementClamp, transform.position.y);
    transform.position = limitPlayerMovement;
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    // if we have collided with an enemy
    // destroy the enemy game object and remove a player life
    if (collision.gameObject.tag == "Enemy") {
      Destroy(collision.gameObject);
      Instantiate(explosionPrefab, collision.gameObject.transform.position, Quaternion.identity);
      SoundEffectsManager.instance.PlayEnemyExplosionSound();
      LoseLife();
    }
  }

  public void LoseLife() { 
    lives--;

    if (lives < 1) {
      Destroy(gameObject);
      Instantiate(explosionPrefab, transform.position, Quaternion.identity);
      SoundEffectsManager.instance.PlayPlayerExplosionSound();
      gameOverScreen.SetActive(true);
      Time.timeScale = 0.3f;
    }
  }
}