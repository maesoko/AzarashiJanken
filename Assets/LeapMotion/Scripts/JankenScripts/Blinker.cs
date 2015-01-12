using UnityEngine;
using System.Collections;

public class Blinker : MonoBehaviour {

	private float nextTime;
	public float interval;	// 点滅周期

	// Use this for initialization
	void Start () {
		nextTime = Time.time;
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
		}

		if(!isBlinking) {
			Reset();
		}
	}

	public void Reset() {
		if(Time.time > nextTime) {
			renderer.enabled = true;
			nextTime += interval;
		}
	}
}
