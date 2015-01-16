using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

	public GameObject[] objects;
	public Texture[] textures;

	// Use this for initialization
	void Start () {
		InitTexture();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ChangeActive(bool isActive) {
		gameObject.SetActive(isActive);
	}

	public void InitTexture() {
		for(int i = 0; i < objects.Length; i++) {
			objects[i].renderer.material.SetTexture("_MainTex", textures[i]);
		}
	}

	public void ChangeTexture(GameObject obj, Texture texture) {
		obj.renderer.material.SetTexture("_MainTex", texture);
	}
}