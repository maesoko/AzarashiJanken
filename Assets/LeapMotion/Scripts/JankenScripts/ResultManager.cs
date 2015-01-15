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
		StartCoroutine(ResultEnd());
	}

	public void GameWin() {
		bgManager.ChangeTexture(azarashi, azarashiWin);
		bgManager.ChangeTexture(resultMessage, winMessage);
		bgManager.ChangeActive(true);
		StartCoroutine(ResultEnd());
	}

	private IEnumerator ResultEnd() {
		yield return new WaitForSeconds(GameManager.WAIT_TIME);
		isResultEnd = true;
	}
}
