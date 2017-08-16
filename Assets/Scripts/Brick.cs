using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public static int brickCount = 0;

	public AudioClip crack;
	public Sprite[] hitSprites;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable){
			brickCount++;
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}


	void OnCollisionEnter2D(Collision2D ball){
		AudioSource.PlayClipAtPoint (crack, transform.position);
		bool isBreakable = (this.tag == "Breakable");

		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits (){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			brickCount--;
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites (){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites[spriteIndex];
		}
	}

	// TODO Remove once we can win
	void SimulateWin(){
		levelManager.LoadNextLevel ();
	}
}
