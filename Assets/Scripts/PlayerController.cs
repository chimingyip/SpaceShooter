using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  // private Rigidbody2D rb;
  [SerializeField] private float moveSpeed = 1f;
  [SerializeField] private float rightMoveBoundary = 1f;
  [SerializeField] private float leftMoveBoundary = -1f;

  private Vector2 moveInput;

  private void Start() {
    // rb = GetComponent<Rigidbody2D>();
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
}