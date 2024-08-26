using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");//On clicking play button loads sample scene
        ScoreManager.instance.scoreText.gameObject.SetActive(true);
    }

    //Quit Game
    public void Quit()
    {
        Application.Quit();//On clicking quit button the player goes out of the game
        Debug.Log("The Player has Quit the game");
    }
    public void Replay()
    {
        SceneManager.LoadScene("MainMenu");//On clicking replay button loads Main Menu
        ScoreManager.instance.ResetScore();//Score set to zero
        ScoreManager.instance.scoreText.gameObject.SetActive(false);

    }
}
