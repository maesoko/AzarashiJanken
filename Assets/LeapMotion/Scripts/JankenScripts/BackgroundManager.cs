using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = (GameObject.Find("GameManager") as GameObject)
			.GetComponent(typeof(GameManager)) as GameManager;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.HandIsValid()) {
			ChangeActive(false);
		}
	}

	public void ChangeActive(bool isActive) {
		gameObject.SetActive(isActive);
	}
}
