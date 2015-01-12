using UnityEngine;
using System.Collections;

public class NoHandMessenger : MonoBehaviour {

	public GameManager gameManager;
	public Blinker blinker;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.HandIsValid()) {
			blinker.Blink(false);
			renderer.enabled = false;
		} else {
			blinker.Blink(true);
		}
	}
}
