using UnityEngine;
using System.Collections;

public class TimeOutChecker : MonoBehaviour {

	public Blinker blinker;
	public int timeoutPeriod = 10;
	private bool timeout;

	public bool TimeOut{
		get{ return timeout; }
		set{ timeout = value; }
	}

	// Use this for initialization
	void Start () {
		timeout = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(blinker.BlinkCount > timeoutPeriod) {
			timeout = true;
		} else {
			timeout = false;
		}
	}
}
