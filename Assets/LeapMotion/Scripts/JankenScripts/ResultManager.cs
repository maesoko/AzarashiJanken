using UnityEngine;
using System.Collections;

public class ResultManager : MonoBehaviour {

	public BackgroundManager bgManager;
	public GameObject resultMessage;
	public GameObject azarashi;
	public Texture azarashiWin;
	public Texture winMessage;
	public Texture azarashiRetry;
	public Texture retryMessage;
	private bool isResultEnd;
	public RoundManager roundManager;
	public AudioClip azarashiWinVoice;
	public AudioClip winSE;
	public AudioClip azarashiRetryVoice;
	public AudioClip retrySE;
	public AudioClip endVoice;

	public bool IsResultEnd{
		get { return isResultEnd;}
	}

	void OnDisable() {
		isResultEnd = false;
	}

	public void GameRetry() {
		bgManager.ChangeTexture(azarashi, azarashiRetry);
		bgManager.ChangeTexture(resultMessage, retryMessage);
		bgManager.ChangeActive(true);
		gameObject.audio.PlayOneShot(retrySE, 0.2f);
		gameObject.audio.PlayOneShot(azarashiRetryVoice);
		StartCoroutine(ResultEnd());
	}

	public void GameWin() {
		bgManager.ChangeTexture(azarashi, azarashiWin);
		bgManager.ChangeTexture(resultMessage, winMessage);
		bgManager.ChangeActive(true);
		gameObject.audio.PlayOneShot(winSE, 0.2f);
		gameObject.audio.PlayOneShot(azarashiWinVoice);
		StartCoroutine(ResultWin());
	}

	private IEnumerator ResultEnd() {
		yield return new WaitForSeconds(GameManager.WAIT_TIME);
		isResultEnd = true;
	}

	private IEnumerator ResultWin() {
		roundManager.EnemyWin();
		if(roundManager.IsFinalRound) {
			yield return new WaitForSeconds(GameManager.WAIT_TIME);
			gameObject.audio.PlayOneShot(endVoice);
			yield return StartCoroutine(ResultEnd());
		} else {
			yield return StartCoroutine(ResultEnd());
		}
	}
}
