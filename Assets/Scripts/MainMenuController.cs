using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {
    public void StartGame()
    {
        Invoke("Play", 1.0f);
        
    }

    public void Play()
    {
        Application.LoadLevel(1);
    }
}
