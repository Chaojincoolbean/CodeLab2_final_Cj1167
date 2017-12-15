using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlessYouGameManager : MonoBehaviour {

	public GameObject SneezeMan;
	public GameObject Score;
	public AudioSource As;
	public AudioSource Thankyou;
	public AudioSource SneezeSound;
	public float CoolDownTimer;
	public int MissTimes;
	public int GameScore;
	public Animator Sneeze;

	// Use this for initialization
	void Start () {

		As = this.gameObject.GetComponent<AudioSource> ();
		Thankyou = Score.gameObject.GetComponent<AudioSource> ();
		Sneeze = SneezeMan.gameObject.GetComponent<Animator> ();
		SneezeSound = SneezeMan.gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		CoolDownTimer = CoolDownTimer + Time.deltaTime;

		if (Input.GetMouseButtonDown (0) && CoolDownTimer > 1f) {

			GetInput ();
		}

		if (Input.GetKeyDown(KeyCode.Space) && CoolDownTimer > 1f) {

			GetInput ();
		}

	}

	public void Blessyou(){
		
		SneezeSound.Pause();
		Sneeze.speed = 0f;
		Thankyou.Play ();
		GameScore++;
		PlayerPrefs.SetInt ("score", GameScore);
		StartCoroutine ("ThankYou");
	
	}

	public void GetInput(){

		CoolDownTimer = 0;

		As.Play ();

		if (SneezeMan.GetComponent<SpriteRenderer> ().sprite.name == "frame_22_delay-0.04s") {

			Blessyou ();

		} else if (SneezeMan.GetComponent<SpriteRenderer> ().sprite.name == "frame_23_delay-0.1s") {

			Blessyou ();
		} 

		else MissTimes++;

		if (MissTimes >= 10) {
			SceneManager.LoadScene (2);
		}
	
	}


	IEnumerator ThankYou()
	{
		yield return new WaitForSeconds (1);

		SneezeSound.UnPause();
		Sneeze.speed = 1f;

	}


		
}
