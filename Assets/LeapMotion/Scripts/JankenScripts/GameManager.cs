using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

 	private HandController controller;

	// Use this for initialization
	void Start () {
		controller = (GameObject.Find("HandController") as GameObject)
			.GetComponent(typeof(HandController)) as HandController;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool HandIsValid() {
		return controller.GetFrame().Fingers.Count > 0;
	}
}
