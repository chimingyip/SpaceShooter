using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  // private Rigidbody2D rb;
  [SerializeField] private float moveSpeed = 1f;
  [SerializeField] private float rightMoveBoundary = 1f;
  [SerializeField] private float leftMoveBoundary = -1f;

  [SerializeField] private int _lives = 4;
  public int Lives { get => _lives; }

  private Vector2 moveInput;

  private void FixedUpdate() {
    Debug.Log(_lives);
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
      LoseLife();
    }
  }

  private void LoseLife() { 
    _lives--;

    if (_lives < 1) {
      // load game over UI
    }
  }
}