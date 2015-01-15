using UnityEngine;
using System.Collections;

public class VoiceManager : MonoBehaviour {

	private bool playBack;

	// Use this for initialization
	void Start () {
		playBack = false;
	}
	
	void OnWillRenderObject() {
		if(!playBack) {
			print("hoge");
			gameObject.audio.Play();
			playBack = true;
		}
	}
}
