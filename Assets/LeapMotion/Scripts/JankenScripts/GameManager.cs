using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public HandController handController;
	public TopScreen topScreen;
	public BackgroundManager topBgManager;
	public BackgroundManager uiBgManager;
	public BackgroundManager gameBgManager;
	public TimeOutChecker timeOutChecker;

	public int ExtendedFingers{
		get{return handController.GetFrame().Fingers.Extended().Count;}
	}

	public bool GameIsPlaying{
		get{ return !topScreen.IsDisplayed; }
	}

	// Use this for initialization
	void Start () {
		//ゲーム初期化
		init();
	}

	private void GameSetup(){
		uiBgManager.ChangeActive(true);
		gameBgManager.ChangeActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(GameIsPlaying) {

			GameSetup();

			if(timeOutChecker.TimeOut) {
				GameReset();
			}

		} else {
			init();
		}
	}

	private void GameReset(){
		topScreen.IsDisplayed = true;
		topBgManager.ChangeActive(true);
		timeOutChecker.TimeOut = false;
	}

	public bool HandIsValid() {
		return handController.GetFrame().Fingers.Count > 0;
	}

	public void init() {
		uiBgManager.ChangeActive(false);
		gameBgManager.ChangeActive(false);
	}
}