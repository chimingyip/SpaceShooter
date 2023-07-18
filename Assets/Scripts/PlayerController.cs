using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  [SerializeField] public float moveSpeed = 1f;
  private Rigidbody2D rb;

  private Vector2 moveInput;

  private void Start() {
    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {
    rb.MovePosition(rb.position + moveInput * moveSpeed * Time.deltaTime);
  }

  void OnMove(InputValue value) {
    moveInput = value.Get<Vector2>();
  }
}