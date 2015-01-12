using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public HandController handController;
	public TopScreen topScreen;
	public BackgroundManager uiBgManager;
	public BackgroundManager gameBgManager;
	private TimeOutChecker timeOutChecker;

	public int ExtendedFingers{
		get{return handController.GetFrame().Fingers.Extended().Count;}
	}

	// Use this for initialization
	void Start () {
		//ゲーム初期化
		init();
	}
	
	// Update is called once per frame
	void Update () {
		if(!topScreen.IsDisplayed) {
			uiBgManager.ChangeActive(true);
			gameBgManager.ChangeActive(true);
		}
	}

	public bool HandIsValid() {
		return handController.GetFrame().Fingers.Count > 0;
	}

	public void init() {
		uiBgManager.ChangeActive(false);
		gameBgManager.ChangeActive(false);
	}
}