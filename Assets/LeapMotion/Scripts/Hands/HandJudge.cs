using UnityEngine;
using System.Collections;

public class HandJudge : MonoBehaviour {

	public const int DRAW = 0;
	public const int LOSE = 1;
	public const int WIN = 2;
	public const int INVALID = -1;
	private GUIText judgeText;
	private GUIText resultText;

	// Use this for initialization
	void Start () {
		judgeText = gameObject.GetComponent(typeof(GUIText)) as GUIText;
		resultText = (GameObject.Find("ResultText") as GameObject)
			.GetComponent(typeof(GUIText)) as GUIText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int Judge(int player, int enemy) {
		int judge = (player - enemy + 3) % 3;
		int result = -1;

		if(player == INVALID) {
			judgeText.text = "やりなおし";
			return INVALID;
		}

		switch (judge) {
		case DRAW: 
			result = DRAW;
			judgeText.text = "引き分け";
			break;
		case LOSE: 
			result = LOSE;
			judgeText.text = "負け";
			resultText.text += "X";
			break;
		case WIN: 
			result = WIN;
			judgeText.text = "勝ち";
			resultText.text += "◯";
			break;
		}

		return result;
	}
}
