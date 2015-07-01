using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

	public int count;
	public int levelLength;
	public int success;
	public int victories;

	public float timer;
	public float delay;
	public float reactionTime;

	private bool qLeft;
	private bool wMiddle;
	private bool eRight;

	private float rage;
	private float satisfaction;
	private float salt;

	public Button left;
	public Button middle;
	public Button right;
	public Button startButton;
	public Button cookScene;
	public Button buyNewKeyboard;

	public Text rageText;
	public Text satisfactionText;
	public Text winAmount;

	private string screenRage;
	private string screenSatisfaction;
	private string screenVictories;

	private bool levelPlaying;

	public Slider rageMeter;
	public Slider satisfactionMeter;
	public Slider saltMeter;

	public bool keyboard;
	public int keyboardHealth;
	public GameObject broken;

	void Start () {

		victories = GameGlobals.GetWins ();
		salt = GameGlobals.GetSalt ();
		rage = GameGlobals.GetRage ();
		satisfaction = GameGlobals.GetSatisfaction ();

		rageMeter = rageMeter.GetComponent<Slider> ();
		satisfactionMeter = satisfactionMeter.GetComponent<Slider> ();
		saltMeter = saltMeter.GetComponent<Slider> ();
		left = left.GetComponent<Button> ();
		middle = middle.GetComponent<Button> ();
		right = right.GetComponent<Button> ();
		startButton = startButton.GetComponent<Button> ();
		cookScene = cookScene.GetComponent<Button> ();
		buyNewKeyboard = buyNewKeyboard.GetComponent<Button> ();

		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;

		qLeft = false;
		wMiddle = false;
		eRight = false;

		delay = 0.1f;
		reactionTime = 50f;
		levelLength = 8;

		rageMeter.value = rage;
		satisfactionMeter.value = satisfaction;
		saltMeter.value = salt;

		levelPlaying = false;
		keyboard = GameGlobals.GetKeyboard ();
		keyboardHealth = GameGlobals.GetKeyboardHealth ();

	}
	

	void Update () {

		timer++;

		screenRage = rage.ToString();
		screenSatisfaction = satisfaction.ToString();
		screenVictories = victories.ToString ();

		rageText.text = ("Rage: " + screenRage);
		satisfactionText.text = ("Satisfaction: " + screenSatisfaction);
		winAmount.text = ("Victories: " + screenVictories);

		if (levelPlaying == true && keyboard == true) {
			if (Input.GetButtonDown ("Fire1")) {
				if (qLeft == true) {
					satisfaction = satisfaction + 0.5f;
					success++;
					QSwitchFalse ();
					screenSatisfaction = satisfaction.ToString ();
					satisfactionText.text = ("Satisfaction: " + screenSatisfaction);		
					satisfactionMeter.value = satisfaction;
				} else { 
					rage = rage + 1f;
					rageText.text = ("Rage: " + screenRage);
					screenRage = rage.ToString ();
					rageMeter.value = rage;
				}
			}
		}

		if (levelPlaying == true && keyboard == true) {
			if (Input.GetButtonDown ("Fire2")) {
				if (wMiddle == true) {
					satisfaction = satisfaction + 0.5f;
					success++;
					WSwitchFalse ();
					screenSatisfaction = satisfaction.ToString ();
					satisfactionText.text = ("Satisfaction: " + screenSatisfaction);
					satisfactionMeter.value = satisfaction;
				} else {
					rage = rage + 1f;
					rageText.text = ("Rage: " + screenRage);
					screenRage = rage.ToString ();
					rageMeter.value = rage;
				}
			}
		}

		if (levelPlaying == true && keyboard == true) {
			if (Input.GetButtonDown ("Fire3")) {
				if (eRight == true) {
					satisfaction = satisfaction + 0.5f;
					success++;
					ESwitchFalse ();
					screenSatisfaction = satisfaction.ToString ();
					satisfactionText.text = ("Satisfaction: " + screenSatisfaction);
					satisfactionMeter.value = satisfaction;
				} else {
					rage = rage + 1f;
					rageText.text = ("Rage: " + screenRage);
					screenRage = rage.ToString ();
					rageMeter.value = rage;
				}
			}
		}

		if (Input.GetButtonDown("Jump") && keyboard == true){
			keyboardHealth--;
			rage = rage - 10;
			GameGlobals.SetRage(rage);
			if (keyboardHealth <= 0){
				Instantiate (broken, new Vector2 (0, 0), Quaternion.identity);
				keyboard = false;
				GameGlobals.SetKeyboard(keyboard);
			}
		}

		if (timer >= reactionTime && qLeft == true) {
			rage = rage + 1f;
			QSwitchFalse();
			rageMeter.value = rage;
		}
		if (timer >= reactionTime && wMiddle == true) {
			rage = rage + 1f;
			WSwitchFalse();
			rageMeter.value = rage;
		}
		if (timer >= reactionTime && eRight == true) {
			rage = rage + 1f;
			ESwitchFalse();
			rageMeter.value = rage;
		}

		if (keyboard == false) {
			buyNewKeyboard.interactable = true;
		} else {
			buyNewKeyboard.interactable = false;
		}

		if (rage < 0) {
			rage = 0;
			GameGlobals.SetRage(rage);
		}
		if (satisfaction < 0) {
			satisfaction = 0;
			GameGlobals.SetSatisfaction(satisfaction);
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
			if (success > levelLength / 2){
				victories++;
			} else{
				rage = rage + 10;
			}
			if (keyboard == true){
				keyboardHealth = 5;
				GameGlobals.SetKeyBoardHealth(keyboardHealth);
			}
			GameGlobals.SetWins(victories);
			GameGlobals.SetSatisfaction (satisfaction);
			GameGlobals.SetRage (rage);
			startButton.interactable = true;
			levelPlaying = false;
			success = 0;
		}
	}

	public void StartTheGame()
	{
		levelPlaying = true;
		count = 0;
		timer = 0;
		success = 0;
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
		success = 0;
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

	public void ToTheKitchen()
	{
		Application.LoadLevel (2);
	}

	public void BuyNewKeyboard()
	{
		if (satisfaction > 1) {
			satisfaction = satisfaction - 5;
			rage = rage + 10;
			salt = salt - 100;
			GameGlobals.SetSatisfaction (satisfaction);
			GameGlobals.SetRage (rage);
			GameGlobals.SetSalt (salt);
		} else {
			Application.LoadLevel(3);
		}
	}
	
}
