using UnityEngine;
using System.Collections;

public class HandChecker : MonoBehaviour {

	public GameManager gameManager;
	public Blinker rock;
	public Blinker scissors;
	public Blinker paper;
	private const int ROCK = 0;
	private const int SCISSORS  = 2;
	private const int PAPER  = 5;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.HandIsValid()) {
			HandCheck(gameManager.ExtendedFingers);
		} else {
			BlinkReset();
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
			break;
		case SCISSORS:
			rock.Blink(false);
			scissors.Blink(true);
			paper.Blink(false);
			break;
		case PAPER:
			rock.Blink(false);
			scissors.Blink(false);
			paper.Blink(true);
			break;
		default:
			BlinkReset();
			break;
		}

	}
}
