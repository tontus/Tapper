using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
	void Update ()
	{
		if (score > 0)
		velocity = (float) ((float) (Math.Log10(score) + 2f) + (score / Math.Sqrt(score)));
		scoreText.text = score.ToString();
	}

	public void GameOver()
	{
		return;
	}
	
}
