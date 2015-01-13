using UnityEngine;
using System.Collections;

public class MessageChanger : MonoBehaviour {

	public Texture afterMessage;
	private bool isChanged;

	// Use this for initialization
	void Start () {
		isChanged = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameObject.audio.isPlaying) {
			isChanged = true;
		}

		if(isChanged) {
			MessageChange(afterMessage);
			isChanged = false;
		}
	}

	private void MessageChange(Texture message) {
		gameObject.renderer.material.SetTexture("_MainTex", message);
	}
}
