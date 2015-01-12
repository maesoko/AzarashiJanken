using UnityEngine;
using System.Collections;

public class TimeOutChecker : MonoBehaviour {

	private const float TIME_OUT = 10.0f;
	private float elapsedTime = 0f;
	private float interval = 1.0f;
	private float nextTime;
	private bool timeOut = false;

	public bool IsTimedOut{
		get{return timeOut;}
	}

	// Use this for initialization
	void Start () {
		nextTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(elapsedTime > TIME_OUT) {
			timeOut = true;
			elapsedTime = 0f;
		}
	}

	public void CheckForTimeOut(bool isCheck) {
		while(isCheck) {
			if(Time.time > nextTime) {
				elapsedTime += 1.0f;
				nextTime += interval;
			}
		}

		if(!isCheck) {
			elapsedTime = 0f;
		}
	}
}
