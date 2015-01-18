using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {

	public Animator animator;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		animator.speed = speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
