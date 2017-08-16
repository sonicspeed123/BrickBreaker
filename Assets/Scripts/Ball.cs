using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVect; 

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVect = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVect;

			if (Input.GetMouseButtonDown (0)) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
				hasStarted = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		Vector2 tweak = new Vector2 (Random.Range (0f, .2f), Random.Range (0f, .2f));
		if (hasStarted) {
			GetComponent<AudioSource> ().Play ();
			GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}
}
