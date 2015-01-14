using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

	public GameObject[] objects;
	public Texture[] textures;

	// Use this for initialization
	void Start () {
		init(objects, textures);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ChangeActive(bool isActive) {
		gameObject.SetActive(isActive);
	}

	private void init(GameObject[] obj, Texture[] images) {
		for(int i = 0; i < obj.Length; i++) {
			obj[i].renderer.material.SetTexture("_MainTex", images[i]);
		}
	}

	public void ChangeTexture(GameObject obj, Texture texture) {
		obj.renderer.material.SetTexture("_MainTex", texture);
	}
}