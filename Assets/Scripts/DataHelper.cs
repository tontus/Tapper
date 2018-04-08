using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHelper : MonoBehaviour {

	// Use this for initialization
	public static DataHelper instance;
	public int atempts;

	// Use this for initialization
	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		
	}

	private void Start()
	{
		atempts = 0;
	}
}
