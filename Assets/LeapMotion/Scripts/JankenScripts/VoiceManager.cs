using UnityEngine;
using System.Collections;

public class VoiceManager : MonoBehaviour {

	private bool playBackStart;

	// Use this for initialization
	void Start () {
		playBackStart = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(playBackStart) {
			gameObject.audio.Play();
			playBackStart = false;
		}
	}

	public void PlayVoice() {
		playBackStart = true;
	}

}
