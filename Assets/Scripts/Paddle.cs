using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Input.mousePosition gets XYZ position of x.
//divide by screen.width to get a value from 0 to 1
//then multiply by 16 (amount of blocks across)

public class Paddle : MonoBehaviour {
	public bool autoPlay = false;
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MovewithMouse ();
		} else {
			AutoPlay ();
		}
	}

	void AutoPlay (){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}

	void MovewithMouse(){
		float mousePosX = Mathf.Clamp (Input.mousePosition.x / Screen.width * 16, 0.5f, 15.5f);
		//keep current y position
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		paddlePos.x = mousePosX;
		this.transform.position = paddlePos;
	}
}
