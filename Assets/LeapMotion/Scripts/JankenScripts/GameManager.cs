using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public HandController handController;
	public TopScreen topScreen;
	public BackgroundManager topBgManager;
	public BackgroundManager uiBgManager;
	public BackgroundManager gameBgManager;
	public TimeOutChecker timeOutChecker;
	public MessageChanger msgChenger;
	private bool setupCompleted;

	public int ExtendedFingers{
		get{return handController.GetFrame().Fingers.Extended().Count;}
	}

	public bool GameIsPlaying{
		get{ return !topScreen.IsDisplayed; }
	}

	public bool HandIsValid{
		get {return handController.GetFrame().Fingers.Count > 0;}
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
				GameReset();
			}

		}
	}

	private void GameReset() {
		init();
		topScreen.IsDisplayed = true;
		topBgManager.ChangeActive(true);
		timeOutChecker.TimeOut = false;
	}

	public void init() {
		setupCompleted = false;
		uiBgManager.ChangeActive(false);
		gameBgManager.ChangeActive(false);
	}
}