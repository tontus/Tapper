using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePrefabs : MonoBehaviour
{
	[SerializeField] private GameObject row;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Row"))
		{
			
			Instantiate(row, new Vector3(0f, GameController.instance.spawnHeight, 0f), Quaternion.identity);
		}
	}
}
