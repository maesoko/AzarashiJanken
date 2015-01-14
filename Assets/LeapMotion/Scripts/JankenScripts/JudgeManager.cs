using UnityEngine;
using System.Collections;

public class JudgeManager : MonoBehaviour {

	public BackgroundManager bgManager;
	public GameObject azarashiHand;
	public GameObject playerHand;
	public Texture playerRock;
	public Texture playerScissors;
	public Texture playerPaper;
	public Texture azarashiRock;
	public Texture azarashiScissors;
	public Texture azarashiPaper;
	public VoiceManager voice;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Judge(int hand) {
		switch (hand) {
		case HandChecker.ROCK:
			bgManager.ChangeTexture(playerHand, playerRock);
			bgManager.ChangeTexture(azarashiHand, azarashiPaper);
			break;
		case HandChecker.SCISSORS:
			bgManager.ChangeTexture(playerHand, playerScissors);
			bgManager.ChangeTexture(azarashiHand, azarashiRock);
			break;
		case HandChecker.PAPER:
			bgManager.ChangeTexture(playerHand, playerPaper);
			bgManager.ChangeTexture(azarashiHand, azarashiScissors);
			break;
		default:
			//TODO:判定不可画面を表示させる
			print("INVALID");
			break;
		}
		voice.PlayVoice();
	}
}
