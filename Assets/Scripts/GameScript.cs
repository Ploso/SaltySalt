using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

	public int count;
	public int levelLength;

	public float timer;
	public float delay;
	public float reactionTime;

	private bool qLeft;
	private bool wMiddle;
	private bool eRight;

	private float rage;
	private float satisfaction;
	private int salt;

	public Button left;
	public Button middle;
	public Button right;
	public Button startButton;

	public Text rageText;
	public Text satisfactionText;

	private string screenRage;
	private string screenSatisfaction;

	private bool levelPlaying;


	void Start () {
		salt = GameGlobals.GetSalt ();
		rage = GameGlobals.GetRage ();
		satisfaction = GameGlobals.GetSatisfaction ();

		left = left.GetComponent<Button> ();
		middle = middle.GetComponent<Button> ();
		right = right.GetComponent<Button> ();
		startButton = startButton.GetComponent<Button> ();

		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;

		qLeft = false;
		wMiddle = false;
		eRight = false;

		delay = 0.1f;
		reactionTime = 50f;
		levelLength = 8;

		levelPlaying = false;

	}
	

	void Update () {

		timer++;

		screenRage = rage.ToString();
		screenSatisfaction = satisfaction.ToString();

		rageText.text = ("Rage: " + screenRage);
		satisfactionText.text = ("Satisfaction: " + screenSatisfaction);

		if (levelPlaying == true) {
			if (Input.GetButtonDown ("Fire1")) {
				if (qLeft == true) {
					satisfaction = satisfaction + 0.5f;
					QSwitchFalse ();
					screenSatisfaction = satisfaction.ToString ();
					satisfactionText.text = ("Satisfaction: " + screenSatisfaction);
				} else { 
					rage = rage + 1f;
					rageText.text = ("Rage: " + screenRage);
					screenRage = rage.ToString ();
				}
			}
		}

		if (levelPlaying == true) {
			if (Input.GetButtonDown ("Fire2")) {
				if (wMiddle == true) {
					satisfaction = satisfaction + 0.5f;
					WSwitchFalse ();
					screenSatisfaction = satisfaction.ToString ();
					satisfactionText.text = ("Satisfaction: " + screenSatisfaction);
				} else {
					rage = rage + 1f;
					rageText.text = ("Rage: " + screenRage);
					screenRage = rage.ToString ();
				}
			}
		}

		if (levelPlaying == true) {
			if (Input.GetButtonDown ("Fire3")) {
				if (eRight == true) {
					satisfaction = satisfaction + 0.5f;
					ESwitchFalse ();
					screenSatisfaction = satisfaction.ToString ();
					satisfactionText.text = ("Satisfaction: " + screenSatisfaction);
				} else {
					rage = rage + 1f;
					rageText.text = ("Rage: " + screenRage);
					screenRage = rage.ToString ();
				}
			}
		}

		if (timer >= reactionTime && qLeft == true) {
			rage = rage + 1f;
			QSwitchFalse();
		}
		if (timer >= reactionTime && wMiddle == true) {
			rage = rage + 1f;
			WSwitchFalse();
		}
		if (timer >= reactionTime && eRight == true) {
			rage = rage + 1f;
			ESwitchFalse();
		}
	}

	public void QSwitchTrue ()
	{
		if (qLeft == false) {
			qLeft = true;
		}
		left.interactable = true;
	}

	public void QSwitchFalse ()
	{
		if (qLeft == true) {
			qLeft = false;
		}
		left.interactable = false;
		Invoke ("GameStarter", delay);
	}
	
	public void WSwitchTrue ()
	{
		if (wMiddle == false) {
			wMiddle = true;
		}
		middle.interactable = true;
	}

	public void WSwitchFalse ()
	{
		if (wMiddle == true) {
			wMiddle = false;
		}
		middle.interactable = false;
		Invoke ("GameStarter", delay);
	}
	
	public void ESwitchTrue ()
	{
		if (eRight == false) {
			eRight = true;
		}
		right.interactable = true;
	}

	public void ESwitchFalse ()
	{
		if (eRight == true) {
			eRight = false;
		}
		right.interactable = false;
		Invoke ("GameStarter", delay);
	}
	

	public void GameStarter ()
	{
		if (count <= levelLength) {
			count++;
			timer = 0;
			int rng;
			rng = Random.Range (1, 4);

			if (rng == 1) {
				Invoke ("QSwitchTrue", delay);
			} else if (rng == 2) {
				Invoke ("WSwitchTrue", delay);
			} else if (rng == 3) {
				Invoke ("ESwitchTrue", delay);
			} else {
				Invoke ("WSwitchTrue", delay);
			}
		} else {
			startButton.interactable = true;
			levelPlaying = false;
		}
	}

	public void StartTheGame()
	{
		levelPlaying = true;
		count = 0;
		timer = 0;
		GameStarter ();
		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;
		
		qLeft = false;
		wMiddle = false;
		eRight = false;
		startButton.interactable = false;
	}

	public void StartTheHardGame()
	{
		levelPlaying = true;
		count = 0;
		timer = 0;
		GameStarter ();
		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;

		delay = 0.1f;
		reactionTime = 25f;
		levelLength = 25;
		
		qLeft = false;
		wMiddle = false;
		eRight = false;
		startButton.interactable = false;
	}
}
