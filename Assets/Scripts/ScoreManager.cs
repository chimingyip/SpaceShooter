using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }

    public Sprite[] digitSprites;
    public Image[] digitImages;
    private int currentScore = 0; // Initial score

    void Start()
    {
        if (instance == null) {
            instance = this;
        }
        
        UpdateScoreUI(); // Display initial score when the game starts
    }

    // Function to update the score
    public void UpdateScore(int scoreIncrease)
    {
        currentScore += scoreIncrease; // Increment the score by the given amount
        currentScore = Mathf.Clamp(currentScore, 0, 999999); // Ensure the score doesn't go beyond 999999
        UpdateScoreUI(); // Update the displayed score
    }

    // Function to update the displayed score in the UI
    void UpdateScoreUI()
    {
        string scoreString = currentScore.ToString().PadLeft(6, '0'); // Convert score to string and pad with zeros to make it 6 digits
        for (int i = 0; i < 6; i++)
        {
            int digit = int.Parse(scoreString[i].ToString()); // Get individual digit at index i
            digitImages[i].sprite = digitSprites[digit]; // Set the corresponding sprite for the digit
        }
    }
}
