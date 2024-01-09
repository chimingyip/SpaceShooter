using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance; // Singleton instance

    public AudioSource audioSource;
    public AudioClip mainMenuMusic;
    public AudioClip gameSceneMusic;

    private void Awake()
    {
        // Ensure only one instance of MusicManager exists
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
    void Start()
    {
        // Ensure AudioSource is assigned
        if (audioSource == null)
        {
            Debug.LogError("Please assign an AudioSource.");
            return;
        }

        // Check the current active scene and play the appropriate music
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainMenu")
        {
            PlayMusic(mainMenuMusic);
        }
        else if (currentScene.name == "GameScene")
        {
            PlayMusic(gameSceneMusic);
        }

        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check the loaded scene and play the appropriate music
        if (scene.name == "MainMenu")
        {
            PlayMusic(mainMenuMusic);
        }
        else if (scene.name == "GameScene")
        {
            PlayMusic(gameSceneMusic);
        }
    }

    void PlayMusic(AudioClip musicClip)
    {
        // Stop the current music track if it's playing
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Assign the new music clip and play it
        audioSource.clip = musicClip;
        audioSource.Play();
    }

    // Method to stop the music
    public void StopMusic()
    {
        audioSource.Stop();
    }

    // Unsubscribe from the event when the script is destroyed
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
