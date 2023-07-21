using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    private void FixedUpdate() {
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime, Space.World);
        // transform.position = Vector2.Lerp(transform.position, new Vector2(0f, -1f), Time.deltaTime * movementSpeed);
    }
}