using UnityEngine;
using System.Collections;
using Leap;

public class HandChecker : MonoBehaviour {

	private GUIText text;
	private HandController controller;
	private string[] hands = {"グー", "チョキ", "パー"};
	private EnemyHand enemyHand;
	private HandJudge judge;
	private int playerHand;
	private const int ROCK = 0;
	private const int SCISSORS = 1;
	private const int PAPER = 2;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent (typeof(GUIText)) as GUIText;
		controller = (GameObject.Find("HandController") as GameObject)
			.GetComponent(typeof(HandController)) as HandController;
		enemyHand = (GameObject.Find("EnemyHand") as GameObject)
			.GetComponent(typeof(EnemyHand)) as EnemyHand;
		judge = (GameObject.Find("JudgeText") as GameObject)
			.GetComponent(typeof(HandJudge)) as HandJudge;
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void handCheck(int fingers) {
		switch(fingers) {
			case 0: 
			playerHand = ROCK;
			break;
			case 2: 
			playerHand = SCISSORS;
			break;
			case 5:
			playerHand = PAPER;
			break;
			default:
			playerHand = HandJudge.INVALID;
			break;
		}
	}

	public void handDisplay(int enemyHand) {
		handCheck(controller.ExtendedFingers);
		if (judge.Judge(playerHand, enemyHand) != HandJudge.INVALID) {
			text.text = "Player: " + hands[playerHand] + " " +
				"Enemy: " + hands[enemyHand];
		}
	}
}
