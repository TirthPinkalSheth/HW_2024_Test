using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
        ScoreManager.instance.scoreText.gameObject.SetActive(true);
    }

    //Quit Game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("The Player has Quit the game");
    }
    public void Replay()
    {
        SceneManager.LoadScene("MainMenu");
        ScoreManager.instance.ResetScore();
        ScoreManager.instance.scoreText.gameObject.SetActive(false);

    }
}
