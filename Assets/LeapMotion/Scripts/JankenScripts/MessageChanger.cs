using UnityEngine;
using System.Collections;

public class MessageChanger : MonoBehaviour {

	public Texture beforeMessage;
	public Texture afterMessage;
	public GameManager gameManager;
	private bool messageIsChanged;
	private bool voiceIsPlaying;
	public AudioClip beforeVoice;
	public AudioClip afterVoice;
	private bool endOfMessage;

	public bool EndOfMessage{
		get {return endOfMessage; }
	}

	// Use this for initialization
	void Start () {
	}

	void OnEnable() {
		messageIsChanged = false;
		endOfMessage = false;
		gameObject.audio.clip = beforeVoice;
		//TODO:初回プレイ時かどうかでメッセージを切り替える
		MessageChange(beforeMessage); //初回プレイ
	}

	void OnDisable() {
		gameObject.audio.clip = null;
	}

	// Update is called once per frame
	void Update () {
		if(gameManager.GameIsPlaying && !messageIsChanged) {
			if(!voiceIsPlaying) {
				PlayBeforeVoice();
				voiceIsPlaying = true;
			}
			
			if(voiceIsPlaying && !gameObject.audio.isPlaying) {
				PlayAfterVoice();
				MessageChange(afterMessage);
				voiceIsPlaying = false;
				messageIsChanged = true;
			}
		}

		if(messageIsChanged && !gameObject.audio.isPlaying) {
			endOfMessage = true;
		}
	}

	private void MessageChange(Texture message) {
		gameObject.renderer.material.SetTexture("_MainTex", message);
	}

	private void PlayBeforeVoice() {
		gameObject.audio.Play();
	}

	private void PlayAfterVoice() {
		gameObject.audio.clip = afterVoice;
		gameObject.audio.Play();
	}
}
