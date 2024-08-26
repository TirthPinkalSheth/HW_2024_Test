using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;  // Tracks the score
    public Text scoreText; // UI Text element to display the score

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of ScoreManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object alive across scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicate ScoreManager objects
        }
    }

    // Method to increment score when Doofus successfully moves to a new pulpit
    public void AddScore(int points)
    {
        score += points;    // Add points (e.g., 1 point per pulpit)
        UpdateScoreText();  // Update the UI with the new score
    }

    // Update the score display on the UI
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score\n" + score.ToString();
        }
    }

    // Reset the score when needed (e.g., at the start of a new game)
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
