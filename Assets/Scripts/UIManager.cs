using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Score tracking

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite heartSprite;

    private void Update() {
        for (int i = 0; i < hearts.Length; i++) {
            if (i < Player.instance.lives) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
