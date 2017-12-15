using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public float score;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


		score = PlayerPrefs.GetInt ("score");

		this.gameObject.GetComponent<TextMesh> ().text = "Score: " + (int)score;

	}
}
