using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndzoneCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Endzone") {
            Debug.Log("Enemy reached endzone");
            Destroy(gameObject);
            Player.instance.LoseLife();
        }
    }
}
