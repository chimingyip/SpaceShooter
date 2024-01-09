using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    public static SoundEffectsManager instance; // Singleton instance

    public AudioSource soundEffectSource;
    public AudioClip enemyExplosionSound;
    public AudioClip powerUpPickUpSound;
    public AudioClip playerExplosionSound;
    public AudioClip laserSound;
    public AudioClip poweredUpLaserSound;
    public AudioClip buttonPressSound;
    public AudioClip endzoneReachedSound;

    [Range(0f, 1f)] // Slider in the Inspector to adjust volume between 0 and 1
    public float soundEffectVolume = 0.5f; // Default volume for sound effects

    private void Awake()
    {
        // Ensure only one instance of SoundEffectsManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep the GameObject between scene changes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Method to play the explosion sound effect
    public void PlayEnemyExplosionSound()
    {
        soundEffectSource.PlayOneShot(enemyExplosionSound, soundEffectVolume);
    }

    public void PlayPlayerExplosionSound()
    {
        soundEffectSource.PlayOneShot(playerExplosionSound, soundEffectVolume);
    }

    // Method to play the laser sound effect
    public void PlayLaserSound()
    {
        soundEffectSource.PlayOneShot(laserSound, soundEffectVolume);
    }

    public void PlayPoweredUpLaserSound()
    {
        soundEffectSource.PlayOneShot(poweredUpLaserSound, soundEffectVolume);
    }

    public void PlayPowerUpPickUpSound()
    {
        soundEffectSource.PlayOneShot(powerUpPickUpSound, soundEffectVolume);
    }

    public void PlayButtonPressSound()
    {
        soundEffectSource.PlayOneShot(buttonPressSound, soundEffectVolume);
    }

    public void PlayEndzoneReachedSound()
    {
        soundEffectSource.PlayOneShot(endzoneReachedSound, soundEffectVolume);
    }

    // Method to change sound effects volume
    public void ChangeSoundEffectsVolume(float newVolume)
    {
        soundEffectVolume = Mathf.Clamp01(newVolume); // Clamp volume between 0 and 1
    }
}
