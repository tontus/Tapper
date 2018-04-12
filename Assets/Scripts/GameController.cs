using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public int score;
	public float velocity;
	public Text scoreText;
	[Range(5f,10f)]
	public float spawnHeight;

	public Button showAdButton;

	public GameObject WatchAdPanel;
	private int restored;
	
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
		restored = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if (score > 0)
		velocity = (float) ((float) (Math.Log10(score) + 2f) + (score /8));
		scoreText.text = score.ToString();
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
			if (hit != null && hit.collider != null)
			{
				if (hit.collider.CompareTag("Circle"))
				{
					Debug.Log("Score");
					AudioManager.instance.Play("Score");
					score++;
					Destroy(hit.collider.gameObject);
				}
			}
		}
	}

	public void GameOver()
	{
		Debug.Log(DataHelper.instance.atempts);
		Time.timeScale = 0f;
//		if (DataHelper.instance.atempts == 3)
//		{
//			DataHelper.instance.atempts = 0;
//			if(Advertisement.IsReady("video"))
//				Advertisement.Show("video");
//		}
//
//		DataHelper.instance.atempts++;
		if (!Advertisement.IsReady("rewardedVideo") || restored != 0)
		{
			ConfirmGameOver();
		}
		else if (restored == 0)
		{
			WatchAdPanel.SetActive(true);
			restored = 1;
		}
			
		

	}

	public void ConfirmGameOver()
	{
		Time.timeScale = 1f;
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
		PlayerPrefs.SetInt("lastscore", score);
		if (score > oldHighscore)
			PlayerPrefs.SetInt("highscore", score);
		Debug.Log(PlayerPrefs.GetInt("highscore"));
		SceneManager.LoadScene(2);
	}

	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
				Debug.Log("The ad was successfully shown.");
				WatchAdPanel.SetActive(false);
				Time.timeScale = 1f;
				break;
			case ShowResult.Skipped:
				Debug.Log("The ad was skipped before reaching the end.");
				break;
			case ShowResult.Failed:
				Debug.LogError("The ad failed to be shown.");
				break;
		}
	}
	
}
