using UnityEngine;
using System.Collections;

public class RoundManager : MonoBehaviour {

	public BackgroundManager bgManager;
	public Texture azarashiWin;
	public GameObject[] rounds;
	private int currentRound;
	private const int FINAL_ROUND = 3;
	private bool isFinalRound;

	public bool IsFinalRound{
		get { return isFinalRound; }
	}

	// Use this for initialization
	void Start () {
		currentRound = 0;
	}

	void OnDisable() {
		isFinalRound = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnemyWin() {
		bgManager.ChangeTexture(rounds[currentRound++], azarashiWin);

		if(currentRound == FINAL_ROUND) {
			currentRound = 0;
			isFinalRound = true;
		}
	}

}
