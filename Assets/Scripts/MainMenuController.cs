using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject scoreText;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            scoreText.GetComponent<TextMeshProUGUI>().text = "High Score:\n" + PlayerPrefs.GetInt("highscore", 0);
        }
        else
        {
            scoreText.GetComponent<TextMeshProUGUI>().text = "Scored: " + PlayerPrefs.GetInt("lastscore", 0) +"\nHigh Score: " + PlayerPrefs.GetInt("highscore", 0);
        }
    }

    public void StartGame()
    {
        Invoke("Play", 1.0f);
        
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }
}
