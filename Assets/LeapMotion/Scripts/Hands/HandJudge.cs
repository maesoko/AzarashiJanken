using UnityEngine;
using System.Collections;

public class HandJudge : MonoBehaviour {

	public const int DRAW = 0;
	public const int LOSE = 1;
	public const int WIN = 2;
	public const int INVALID = -1;
	private GUIText text;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent(typeof(GUIText)) as GUIText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int Judge(int player, int enemy) {
		int judge = (player - enemy + 3) % 3;
		int result = -1;

		if(player == INVALID) {
			text.text = "やりなおし";
			return INVALID;
		}

		switch (judge) {
		case DRAW: 
			result = DRAW;
			text.text = "引き分け";
			break;
		case LOSE: 
			result = LOSE;
			text.text = "負け";
			break;
		case WIN: 
			result = WIN;
			text.text = "勝ち";
			break;
		}

		return result;
	}
}
