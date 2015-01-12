using UnityEngine;
using System.Collections;

public class Blinker : MonoBehaviour {

	private float nextTime;
	public float interval;	// 点滅周期
	private int blinkCount;

	public int BlinkCount{
		get{ return blinkCount; }
	}

	// Use this for initialization
	void Start () {
	}

	void OnEnable() {
		nextTime = Time.time;
		blinkCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Blink(){
		if ( Time.time > nextTime ) {
			renderer.enabled = !renderer.enabled;
			
			nextTime += interval;
		}
	}

	public void Blink(bool isBlinking) {
		if ( Time.time > nextTime && isBlinking) {
			renderer.enabled = !renderer.enabled;
			
			nextTime += interval;
			blinkCount++;
		}

		if(!isBlinking) {
			Reset();
			blinkCount = 0;
		}
	}

	public void Reset() {
		if(Time.time > nextTime) {
			renderer.enabled = true;
			nextTime += interval;
		}
	}
}
