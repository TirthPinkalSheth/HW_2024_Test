using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;  
    public TMP_Text scoreText; //UI text score

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
            Destroy(gameObject); // Duplicate Score Manager is prevented
        }
    }

    // increases the score
    public void AddScore(int points)
    {
        score += points;    
        UpdateScoreText();
        if (score>=50){
            SceneManager.LoadScene("GameOver");
        }
    }

    // Updating the score display on the UI
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score\n" + score.ToString();
        }
    }

    // Reseting the score at start of new game
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
