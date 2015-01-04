using UnityEngine;
using System.Collections;
using Leap;

public class HandChecker : MonoBehaviour {

	private GUIText text;
	private HandController controller;
	private string[] hands = {"グー", "チョキ", "パー"};
	private EnemyHand enemyHand;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent (typeof(GUIText)) as GUIText;
		controller = (GameObject.Find("HandController") as GameObject)
			.GetComponent(typeof(HandController)) as HandController;
		enemyHand = (GameObject.Find("EnemyHand") as GameObject)
			.GetComponent(typeof(EnemyHand)) as EnemyHand;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Player: " + handCheck(controller.ExtendedFingers) + " " +
			"Enemy: " + hands[enemyHand.Hand];
	}

	private string handCheck(int fingers) {
		string hand = "";
		switch(fingers) {
			case 0: hand = "グー"; break;
			case 2: hand = "チョキ"; break;
			case 5: hand = "パー"; break;
			default: hand = ""; break;
		}
		return hand;
	}
}
