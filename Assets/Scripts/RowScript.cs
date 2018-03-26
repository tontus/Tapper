using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowScript : MonoBehaviour
{
	private Rigidbody2D rb2d;
	private GameObject circle;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
		circle = this.gameObject.transform.GetChild(0).gameObject;
		ChangeCirclePosition();
		
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = Vector2.down* GameController.instance.velocity;
	}

	void ChangeCirclePosition()
	{
		int probability = Random.Range(1, 5);
		if (probability > 1)
		{
			float newX = Random.Range(-2f, 2f);
			Vector3 newPosition = circle.transform.localPosition;
			newPosition.x += newX;
			circle.transform.localPosition = newPosition;
		}
		else
		{
			Destroy(circle);
		}
		
	}
}
