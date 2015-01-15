using UnityEngine;
using System.Collections;

public class JudgeManager : MonoBehaviour {

	public BackgroundManager bgManager;
	public HandChanger azarashiHand;
	public HandChanger playerHand;
	public ResultManager resultManager;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool JudgeIsInValid(int hand) {
		return hand == HandChecker.INVALID;
	}

	public void HandJudge(int hand) {
		switch (hand) {
		case HandChecker.ROCK:
			playerHand.HandChange(HandChecker.ROCK);
			azarashiHand.HandChange(HandChecker.PAPER);
			break;
		case HandChecker.SCISSORS:
			playerHand.HandChange(HandChecker.SCISSORS);
			azarashiHand.HandChange(HandChecker.ROCK);
			break;
		case HandChecker.PAPER:
			playerHand.HandChange(HandChecker.PAPER);
			azarashiHand.HandChange(HandChecker.SCISSORS);
			break;
		}
		bgManager.ChangeActive(true);
		StartCoroutine(JudgeEnd());
	}

	private IEnumerator JudgeEnd() {
		yield return new WaitForSeconds(GameManager.WAIT_TIME);
		bgManager.ChangeActive(false);
		resultManager.GameWin();
	}
}
