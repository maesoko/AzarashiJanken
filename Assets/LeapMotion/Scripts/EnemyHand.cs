using UnityEngine;
using System.Collections;

public class EnemyHand : MonoBehaviour {

	private GUITexture texture;
	public Texture[] handsTexture;
	private bool isStop = false;
	private HandChecker handChecker;
	private GaugeManager gauge;


	public bool IsStop {
		get { return isStop; }
		set { isStop = IsStop; }
	}
	
	public int Hand {
		get { return Random.Range(0,3); }
	}

	// Use this for initialization
	void Start () {
		texture = gameObject.GetComponent(typeof(GUITexture)) as GUITexture;
		handChecker = (GameObject.Find("HandText") as GameObject)
			.GetComponent(typeof(HandChecker)) as HandChecker;
		gauge = (GameObject.Find("TimeGauge") as GameObject)
			.GetComponent(typeof(GaugeManager)) as GaugeManager;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount % 3 == 0 && !isStop) {
			texture.texture = handsTexture[Random.Range(0,3)];
		}
	}

	public void ShuffleStop() {
		isStop = true;
	}

	public void HandDecide() {
		int hand = this.Hand;
		ShuffleStop();
		texture.texture = handsTexture[hand];
		handChecker.handDisplay(hand);
		StartCoroutine(DelayStart());
	}

	public IEnumerator DelayStart() {
		yield return new WaitForSeconds(3.0f);
		isStop = false;
		gauge.GaugeReset();
	}
}
