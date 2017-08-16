using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	//when object ball touches trigger losecollider
	void OnTriggerEnter2D(Collider2D ball){
		
	}

	//when object ball collides with invisible box losecollider
	void OnCollisionEnter2D(Collision2D ball){
		
		levelManager.LoadLevel ("Lose");
	}
}
