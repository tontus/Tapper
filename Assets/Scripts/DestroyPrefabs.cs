﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabs : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}
