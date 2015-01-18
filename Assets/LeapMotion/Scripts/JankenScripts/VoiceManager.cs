using UnityEngine;
using System.Collections;

public class VoiceManager : MonoBehaviour {

	private bool playBack;

	// Use this for initialization
	void Start () {
	}
	
	void OnWillRenderObject() {
		if(playBack) {
			gameObject.audio.Play();
			playBack = false;
		}
	}

	void OnEnable() {
		playBack = true;
	}
}
