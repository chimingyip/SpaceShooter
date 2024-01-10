using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; // Singleton instance

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite heartSprite;

    [SerializeField] private Image singleFireMode;
    [SerializeField] private Image doubleFireMode;

    private void Start() {
        if (instance == null) {
            instance = this;
        }
        singleFireMode.enabled = true;
        doubleFireMode.enabled = false;
    }

    private void Update() {
        for (int i = 0; i < hearts.Length; i++) {
            if (i < Player.instance.lives) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

    public void TogglePowerUpIcons(bool activateDoubleIcon)
    {
        singleFireMode.enabled = !activateDoubleIcon;
        doubleFireMode.enabled = activateDoubleIcon;
    }
}
