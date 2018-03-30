using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public int score;
	public float velocity;
	public Text scoreText;
	[Range(5f,10f)]
	public float spawnHeight;
	
	void Awake()
	{
		//If we don't currently have a game control...
		if (instance == null)
			//...set this one to be it...
			instance = this;
		//...otherwise...
		else if (instance != this)
			//...destroy this one because it is a duplicate.
			Destroy(gameObject);
		// DontDestroyOnLoad(Snowfall);
	}
	
	void Start ()
	{
		score = 0;
		velocity = 2f;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if (score > 0)
		velocity = (float) ((float) (Math.Log10(score) + 2f) + (score / Math.Sqrt(score)));
		scoreText.text = score.ToString();
		
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
		if (hit != null && hit.collider != null) {
			if (hit.collider.CompareTag("Circle"))
			{
				Debug.Log("Score");
				score++;
				Destroy(hit.collider.gameObject);
			}
		}
	}

	public void GameOver()
	{
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
		PlayerPrefs.SetInt("lastscore", score);
		if (score > oldHighscore)
			PlayerPrefs.SetInt("highscore", score);
		Debug.Log(PlayerPrefs.GetInt("highscore"));
		SceneManager.LoadScene(2);
	}
	
}
