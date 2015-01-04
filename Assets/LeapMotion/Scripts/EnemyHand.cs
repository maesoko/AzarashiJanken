using UnityEngine;
using System.Collections;

public class EnemyHand : MonoBehaviour {

	private GUITexture texture;
	public Texture[] handsTexture;
	private bool isStop = false;

	public bool IsStop {
		get { return isStop; }
	}
	
	public int Hand {
		get { return Random.Range(0,3); }
	}

	// Use this for initialization
	void Start () {
		texture = gameObject.GetComponent(typeof(GUITexture)) as GUITexture;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount % 3 == 0 && !isStop) {
			texture.texture = handsTexture[Random.Range(0,3)];
		}
	}

	public void ShuffleStop() {
		isStop = true;
	}

	public void HandDecide() {
		ShuffleStop();
		texture.texture = handsTexture[this.Hand];
	}
}
