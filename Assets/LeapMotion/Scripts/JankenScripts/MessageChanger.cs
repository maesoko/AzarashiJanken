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
	public BackgroundManager bgManager;

	public bool EndOfMessage{
		get { return endOfMessage; }
	}

	// Use this for initialization
	void Start () {
	}

	void OnEnable() {

		if(gameManager.IsFirstPlay) {
			bgManager.ChangeTexture(gameObject, beforeMessage);
		} else {
			bgManager.ChangeTexture(gameObject, afterMessage);
		}
	}

	void OnDisable() {
		messageIsChanged = false;
		endOfMessage = false;
		gameObject.audio.clip = null;
	}

	// Update is called once per frame
	void Update () {
		if(gameManager.HandIsValid) {

			if(!messageIsChanged && gameManager.IsFirstPlay) {

				if(!voiceIsPlaying) {
					PlayBeforeVoice();
					voiceIsPlaying = true;
				}
				
				if(voiceIsPlaying && !gameObject.audio.isPlaying) {
					PlayAfterVoice();
					bgManager.ChangeTexture(gameObject, afterMessage);
					voiceIsPlaying = false;
					messageIsChanged = true;
				}
			}

			if(!messageIsChanged && !gameManager.IsFirstPlay) {
				PlayAfterVoice();
				messageIsChanged = true;
			}
			
			if(messageIsChanged && !gameObject.audio.isPlaying) {
				endOfMessage = true;
			}

		}
	}

	private void PlayBeforeVoice() {
		gameObject.audio.clip = beforeVoice;
		gameObject.audio.Play();
	}

	private void PlayAfterVoice() {
		gameObject.audio.clip = afterVoice;
		gameObject.audio.Play();
	}
}
