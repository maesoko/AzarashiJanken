using UnityEngine;
using System.Collections;

public class GaugeManager : MonoBehaviour {

	private SpriteRenderer timeGauge;
	private Vector3 gaugeSize;
	private const float DEFAULT_DECREMENT_TIME = 0.01f;
	private float decrementTime = DEFAULT_DECREMENT_TIME;
	private const float DEFAULT_GAUGE_SIZE = 1.0f;
	private HandController controller;
	public AudioClip[] sounds;
	private bool isFirstStep = true;

	// Use this for initialization
	void Start () {
		timeGauge = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
		gaugeSize = new Vector3(DEFAULT_GAUGE_SIZE, 0.7f, 1.0f);
		controller = (GameObject.Find("HandController") as GameObject)
			.GetComponent(typeof(HandController)) as HandController;
	}
	
	// Update is called once per frame
	void Update () {

		//手が出ているかを判定
		if(HandIsValid()) {

			if (gaugeSize.x >= DEFAULT_GAUGE_SIZE) {
				decrementTime = -decrementTime;
				audio.PlayOneShot(sounds[0]);
			} 

			if (gaugeSize.x < 0) {
					decrementTime = -decrementTime;
					audio.PlayOneShot(sounds[1]);
			} 

			timeGauge.color = ChangeColor(gaugeSize.x);
			gaugeSize.x += decrementTime;
		} else {
			//手が出ていない時の初期化・停止処理
			decrementTime = DEFAULT_DECREMENT_TIME;
			timeGauge.color = Color.green;
			gaugeSize.x = DEFAULT_GAUGE_SIZE;
			audio.Stop();
		}

		timeGauge.transform.localScale = gaugeSize;
	}

	private bool HandIsValid() {
		return controller.GetFrame().Fingers.Count > 0;
	}

	private Color ChangeColor(float gaugeSize) {
		Color color = Color.white;

		if (gaugeSize > 0.6f) {
			color = Color.green;
		} else if (gaugeSize > 0.2f) {
			color = Color.yellow;
		} else {
			color = Color.red;
		}

		return color;
	}
}
