using UnityEngine;
using System.Collections;

public class HandChanger : MonoBehaviour {

	public BackgroundManager bgManager;
	public Texture rock;
	public Texture scissors;
	public Texture paper;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HandChange(int hand) {
		switch(hand) {
		case HandChecker.ROCK:
			bgManager.ChangeTexture(gameObject, rock);
			break;
		case HandChecker.SCISSORS:
			bgManager.ChangeTexture(gameObject, scissors);
			break;
		case HandChecker.PAPER:
			bgManager.ChangeTexture(gameObject, paper);
			break;
		}
	}	
}
