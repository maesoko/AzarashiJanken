using UnityEngine;
using System.Collections;

public class HandChecker : MonoBehaviour {

	public GameManager gameManager;
	public Blinker rock;
	public Blinker scissors;
	public Blinker paper;
	public const int ROCK = 0;
	public const int SCISSORS  = 2;
	public const int PAPER  = 5;
	public const int INVALID = -1;
	private int playerHand = -1;

	public int PlayerHand{
		get { return playerHand; }
	}


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.HandIsValid) {
			HandCheck(gameManager.ExtendedFingers);
		} else {
			BlinkReset();
			playerHand = INVALID;
		}
	}

	private void BlinkReset(){
		rock.Reset();
		scissors.Reset();
		paper.Reset();
	}

	private void HandCheck(int fingerCount) {
		switch(fingerCount) {
		case ROCK:
			rock.Blink(true);
			scissors.Blink(false);
			paper.Blink(false);
			playerHand = ROCK;
			break;
		case SCISSORS:
			rock.Blink(false);
			scissors.Blink(true);
			paper.Blink(false);
			playerHand = SCISSORS;
			break;
		case PAPER:
			rock.Blink(false);
			scissors.Blink(false);
			paper.Blink(true);
			playerHand = PAPER;
			break;
		default:
			BlinkReset();
			playerHand = INVALID;
			break;
		}

	}
}
