using UnityEngine;
using System.Collections;

public class TopScreen : MonoBehaviour {

	public GameManager gameManager;
	private bool isDisplayed = true;
	public BackgroundManager bgManager;
	public Blinker holdUpHandText;

	public bool IsDisplayed{
		get{return isDisplayed;}
		set{isDisplayed = value;}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.HandIsValid) {
			bgManager.ChangeActive(false);
			IsDisplayed = false;
		} else {
			holdUpHandText.Blink();
		}
	}
}
