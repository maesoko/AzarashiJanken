using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public HandController handController;
	public TopScreen topScreen;
	public BackgroundManager topBgManager;
	public BackgroundManager uiBgManager;
	public BackgroundManager gameBgManager;
	public BackgroundManager judgeBgManager;
	public BackgroundManager resultBgManager;
	public TimeOutChecker timeOutChecker;
	public MessageChanger msgChenger;
	public HandChecker handChecker;
	private bool setupCompleted;
	public JudgeManager judgeManager;
	public ResultManager resultManager;
	public const float WAIT_TIME = 3.0f;
	private bool isFirstPlay;

	public int ExtendedFingers{
		get{return handController.GetFrame().Fingers.Extended().Count;}
	}

	public bool GameIsPlaying{
		get{ return !topScreen.IsDisplayed; }
	}

	public bool HandIsValid{
		get {return handController.GetFrame().Fingers.Count > 0;}
	}

	public bool HandJudge{
		get { return msgChenger.EndOfMessage; }
	}

	public bool IsFirstPlay{
		get { return isFirstPlay; }
	}

	// Use this for initialization
	void Start () {
		//ゲーム初期化
		init();
	}

	private void GameSetup(){
		uiBgManager.ChangeActive(true);
		gameBgManager.ChangeActive(true);
		setupCompleted = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameIsPlaying) {

			if(!setupCompleted) {
				GameSetup();
			}

			if(timeOutChecker.TimeOut) {
				GameEnd();
			}

			if(HandJudge) {

				if (judgeManager.JudgeIsInValid(handChecker.PlayerHand)) {
					resultManager.GameRetry();
				} else {
					judgeManager.HandJudge(handChecker.PlayerHand);
				}

				gameBgManager.ChangeActive(false);
			}

			if(resultManager.IsResultEnd) {
				GameReset();
			}
		}
	}

	private void GameEnd() {
		init();
		topScreen.IsDisplayed = true;
		topBgManager.ChangeActive(true);
		timeOutChecker.TimeOut = false;
	}

	public void GameReset() {
		isFirstPlay = false;
		resultBgManager.ChangeActive(false);
		gameBgManager.ChangeActive(true);
	}

	public void init() {
		setupCompleted = false;
		isFirstPlay = true;
		uiBgManager.ChangeActive(false);
		gameBgManager.ChangeActive(false);
		judgeBgManager.ChangeActive(false);
		resultBgManager.ChangeActive(false);
	}
}