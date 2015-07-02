using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

	public int count;
	public int levelLength;
	public int success;
	public int victories;
	public int seaWater;
	
	public float delay;

	private bool qLeft;
	private bool wMiddle;
	private bool eRight;

	private float rage;
	private float satisfaction;
	private float salt;
	private float fail;

	public Button left;
	public Button middle;
	public Button right;
	public Button cookScene;
	public Button buyNewKeyboard;
	public Button startAyyyButton;
	public Button startMayyhemButton;
	public Button startRaheButton;
	public Button startAwesomeButton;
	public Button startStartButton;
	public Button startMobaButton;
	public Button startKnightsButton;

	public bool unlockRahe = false;
	public bool unlockMayyyh = false;
	public bool unlockStayyr = false;
	public bool unlockAwesome = false;
	public bool unlockMoba = false;
	public bool unlockKnights = false;

	public Text rageText;
	public Text satisfactionText;
	public Text winAmount;
	public Text saltGained;
	public Text seaWaterAmount;

	private string screenRage;
	private string screenSatisfaction;
	private string screenVictories;
	private string screenSaltGained;
	private string screenSeaWater;

	private bool levelPlaying;
	private bool rageQuit;
	private bool salted;
	private bool euphoria;

	public Slider rageMeter;
	public Slider satisfactionMeter;
	public Slider saltMeter;

	public bool keyboard;
	public int keyboardHealth;
	public GameObject broken;

	public float points;
	public float victorpoints;
	public Text pointsText;
	private string screenPoints;

	public GameObject completed;

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
		startAyyyButton = startAyyyButton.GetComponent<Button> ();
		startRaheButton = startRaheButton.GetComponent<Button> ();
		startMayyhemButton = startMayyhemButton.GetComponent<Button> ();
		startAwesomeButton = startAwesomeButton.GetComponent<Button> ();
		startStartButton = startStartButton.GetComponent<Button> ();
		startMobaButton = startMobaButton.GetComponent<Button> ();
		startKnightsButton = startKnightsButton.GetComponent<Button> ();
		cookScene = cookScene.GetComponent<Button> ();
		buyNewKeyboard = buyNewKeyboard.GetComponent<Button> ();

		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;

		qLeft = false;
		wMiddle = false;
		eRight = false;

		startRaheButton.interactable = false;
		startMayyhemButton.interactable = false;
		startAwesomeButton.interactable = false;
		startStartButton.interactable = false;
		startMobaButton.interactable = false;
		startKnightsButton.interactable = false;

		cookScene.interactable = false;
		
		delay = 1f;
		levelLength = 8;
		fail = 0;

		rageMeter.value = rage;
		satisfactionMeter.value = satisfaction;
		saltMeter.value = salt;

		levelPlaying = false;
		keyboard = GameGlobals.GetKeyboard ();
		keyboardHealth = GameGlobals.GetKeyboardHealth ();

		saltGained.text = ("");

		rageQuit = false;
		salted = false;
		euphoria = false;

	}
	

	void Update () {

		screenPoints = points.ToString ();
		screenSeaWater = seaWater.ToString ();
		//screenRage = rage.ToString();
		//screenSatisfaction = satisfaction.ToString();
		screenVictories = victories.ToString ();

		pointsText.text = ("Points of saltiness: " + screenPoints);
		seaWaterAmount.text = ("Seawater tanks: " + screenSeaWater);
		//rageText.text = ("Rage: " + screenRage);
		//satisfactionText.text = ("Satisfaction: " + screenSatisfaction);
		winAmount.text = ("Victories: " + screenVictories);

		if (levelPlaying == true && keyboard == true) {
			if (Input.GetButtonDown ("Fire1")) {
				if (qLeft == true) {
					satisfaction = satisfaction + 0.5f;
					success++;
					points++;
					qLeft = false;
					left.interactable = false;
					//screenSatisfaction = satisfaction.ToString ();
					//satisfactionText.text = ("Satisfaction: " + screenSatisfaction);		
					satisfactionMeter.value = satisfaction;
					fail--;
				} else { 
					fail++;
					satisfaction--;
					rage = rage + fail;
					//rageText.text = ("Rage: " + screenRage);
					//screenRage = rage.ToString ();
					rageMeter.value = rage;
					satisfactionMeter.value = satisfaction;
				}
			}
		}

		if (levelPlaying == true && keyboard == true) {
			if (Input.GetButtonDown ("Fire2")) {
				if (wMiddle == true) {
					satisfaction = satisfaction + 0.5f;
					success++;
					points++;
					wMiddle = false;
					middle.interactable = false;
					//screenSatisfaction = satisfaction.ToString ();
					//satisfactionText.text = ("Satisfaction: " + screenSatisfaction);
					satisfactionMeter.value = satisfaction;
					fail--;
				} else {
					fail++;
					satisfaction--;
					rage = rage + fail;
					//rageText.text = ("Rage: " + screenRage);
					//screenRage = rage.ToString ();
					rageMeter.value = rage;
					satisfactionMeter.value = satisfaction;
				}
			}
		}

		if (levelPlaying == true && keyboard == true) {
			if (Input.GetButtonDown ("Fire3")) {
				if (eRight == true) {
					satisfaction = satisfaction + 0.5f;
					success++;
					points++;
					eRight = false;
					right.interactable = false;
					//screenSatisfaction = satisfaction.ToString ();
					//satisfactionText.text = ("Satisfaction: " + screenSatisfaction);
					satisfactionMeter.value = satisfaction;
					fail--;
				} else {
					fail++;
					satisfaction--;
					rage = rage + fail;
					//rageText.text = ("Rage: " + screenRage);
					//screenRage = rage.ToString ();
					rageMeter.value = rage;
					satisfactionMeter.value = satisfaction;
				}
			}
		}

		if (Input.GetButtonDown("Jump") && keyboard == true){
			keyboardHealth--;
			rage = rage - 10;
			rageMeter.value = rage;
			GameGlobals.SetRage(rage);
			if (keyboardHealth <= 0){
				broken.transform.position = new Vector2 (2.14f, -1.83f);
				keyboard = false;
				GameGlobals.SetKeyboard(keyboard);
			}
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
		if (fail < 0) {
			fail = 0;
		}
		if (satisfaction < 0) {
			satisfaction = 0;
			satisfactionMeter.value = satisfaction;
			GameGlobals.SetSatisfaction(satisfaction);
		}
		if (rage >= 100) {
			rageQuit = true;
			GameGlobals.SetRageQuit (rageQuit);
			GameGlobals.SetPoints(points);
			Application.LoadLevel(2);
		}
		if (salt >= 1000) {
			salted = true;
			GameGlobals.SetSalted(salted);
			GameGlobals.SetPoints(points);
			Application.LoadLevel(2);
		}
		if (satisfaction >= 100) {
			euphoria = true;
			GameGlobals.SetEuphoria(euphoria);
			GameGlobals.SetPoints(points);
			Application.LoadLevel(2);
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
		GameStarter ();
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
		GameStarter ();
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
		GameStarter ();
	}
	

	public void GameStarter ()
	{
		if (count <= levelLength) {
			count++;
			int rng;
			rng = Random.Range (1, 4);

			if (rng == 1) {
				StartCoroutine (PressQ());
			} else if (rng == 2) {
				StartCoroutine (PressW());
			} else if (rng == 3) {
				StartCoroutine (PressE());
			} else {
				StartCoroutine (PressW());
			}
		} else {
			seaWater++;
			if (success > levelLength / 2){
				victories++;
				points = points + victorpoints;
			} else{
				rage = rage + 10;
				points = points + (victorpoints / 2);
				rageMeter.value = rage;
			}
			if (keyboard == true){
				keyboardHealth = 5;
				GameGlobals.SetKeyBoardHealth(keyboardHealth);
			}
			GameGlobals.SetWins(victories);
			GameGlobals.SetSatisfaction (satisfaction);
			GameGlobals.SetRage (rage);
			GameGlobals.SetSeaWater(seaWater);
			cookScene.interactable = true;
			buyNewKeyboard.interactable = true;
			startAyyyButton.interactable = true;
			if (unlockRahe == true){
				startRaheButton.interactable = true;;
			}
			if (unlockMayyyh == true){
				startMayyhemButton.interactable = true;
			}
			if (unlockAwesome == true){
				startAwesomeButton.interactable = true;
			}
			if (unlockStayyr == true){
				startStartButton.interactable = true;
			}
			if (unlockMoba == true){
				startMobaButton.interactable = true;
			}
			if (unlockKnights == true){
				startKnightsButton.interactable = true;
			}
			levelPlaying = false;
			success = 0;
			StartCoroutine (CompletedGame());
		}
	}

	public void StartTheGame()
	{
		levelPlaying = true;
		count = 0;
		success = 0;
		fail = 0;

		delay = 1f;
		levelLength = 8;
		victorpoints = 10;
		
		GameStarter ();
		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;
		
		qLeft = false;
		wMiddle = false;
		eRight = false;
		cookScene.interactable = false;
		buyNewKeyboard.interactable = false;
		startAyyyButton.interactable = false;
		startRaheButton.interactable = false;
		startMayyhemButton.interactable = false;
		startAwesomeButton.interactable = false;
		startStartButton.interactable = false;
		startMobaButton.interactable = false;
		startKnightsButton.interactable = false;
	}

	public void StartRaheGame()
	{
		levelPlaying = true;
		count = 0;
		success = 0;
		fail = 0;

		delay = 0.9f;
		levelLength = 16;
		victorpoints = 20;
		
		GameStarter ();
		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;
		
		qLeft = false;
		wMiddle = false;
		eRight = false;
		cookScene.interactable = false;
		buyNewKeyboard.interactable = false;
		startAyyyButton.interactable = false;
		startRaheButton.interactable = false;
		startMayyhemButton.interactable = false;
		startAwesomeButton.interactable = false;
		startStartButton.interactable = false;
		startMobaButton.interactable = false;
		startKnightsButton.interactable = false;
	}

	public void StartMayyyhemGame()
	{
		levelPlaying = true;
		count = 0;
		success = 0;
		fail = 0;
		
		delay = 0.8f;
		levelLength = 16;
		victorpoints = 50;
		
		GameStarter ();
		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;
		
		qLeft = false;
		wMiddle = false;
		eRight = false;
		cookScene.interactable = false;
		buyNewKeyboard.interactable = false;
		startAyyyButton.interactable = false;
		startRaheButton.interactable = false;
		startMayyhemButton.interactable = false;
		startAwesomeButton.interactable = false;
		startStartButton.interactable = false;
		startMobaButton.interactable = false;
		startKnightsButton.interactable = false;
	}

	public void StartStayyrGame()
	{
		levelPlaying = true;
		count = 0;
		success = 0;
		fail = 0;
		
		delay = 0.7f;
		levelLength = 32;
		victorpoints = 100;
		
		GameStarter ();
		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;
		
		qLeft = false;
		wMiddle = false;
		eRight = false;
		cookScene.interactable = false;
		buyNewKeyboard.interactable = false;
		startAyyyButton.interactable = false;
		startRaheButton.interactable = false;
		startMayyhemButton.interactable = false;
		startAwesomeButton.interactable = false;
		startStartButton.interactable = false;
		startMobaButton.interactable = false;
		startKnightsButton.interactable = false;
	}

	public void StartAwesomeGame()
	{
		levelPlaying = true;
		count = 0;
		success = 0;
		fail = 0;
		
		delay = 0.6f;
		levelLength = 32;
		victorpoints = 200;
		
		GameStarter ();
		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;
		
		qLeft = false;
		wMiddle = false;
		eRight = false;
		cookScene.interactable = false;
		buyNewKeyboard.interactable = false;
		startAyyyButton.interactable = false;
		startRaheButton.interactable = false;
		startMayyhemButton.interactable = false;
		startAwesomeButton.interactable = false;
		startStartButton.interactable = false;
		startMobaButton.interactable = false;
		startKnightsButton.interactable = false;
	}
	
	public void StartMobaGame()
	{
		levelPlaying = true;
		count = 0;
		success = 0;
		GameStarter ();
		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;

		delay = 0.5f;
		levelLength = 64;
		victorpoints = 500;
		
		qLeft = false;
		wMiddle = false;
		eRight = false;
		cookScene.interactable = false;
		buyNewKeyboard.interactable = false;
		startAyyyButton.interactable = false;
		startRaheButton.interactable = false;
		startMayyhemButton.interactable = false;
		startAwesomeButton.interactable = false;
		startStartButton.interactable = false;
		startMobaButton.interactable = false;
		startKnightsButton.interactable = false;
	}

	public void StartKnightGame()
	{
		levelPlaying = true;
		count = 0;
		success = 0;
		GameStarter ();
		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;
		
		delay = 0.4f;
		levelLength = 64;
		victorpoints = 1000;
		
		qLeft = false;
		wMiddle = false;
		eRight = false;
		cookScene.interactable = false;
		buyNewKeyboard.interactable = false;
		startAyyyButton.interactable = false;
		startRaheButton.interactable = false;
		startMayyhemButton.interactable = false;
		startAwesomeButton.interactable = false;
		startStartButton.interactable = false;
		startMobaButton.interactable = false;
		startKnightsButton.interactable = false;
	}
	
	public void BuyNewKeyboard()
	{
		if (satisfaction > 1) {
			satisfaction = satisfaction - 5;
			rage = rage + 10;
			rageMeter.value = rage;
			satisfactionMeter.value = satisfaction;
			GameGlobals.SetSatisfaction (satisfaction);
			GameGlobals.SetRage (rage);
			broken.transform.position = new Vector2(100,100);
			keyboard = true;
			keyboardHealth = 5;
			GameGlobals.SetKeyboard (keyboard);
			GameGlobals.SetKeyBoardHealth (keyboardHealth);
		} else {
			GameGlobals.SetPoints(points);
			Application.LoadLevel(2);
		}
	}

	public void Cook ()
	{
		int multiply;
		int rngInt;
		float totalRage;
		float pleasure;
		float tempSaltGained;

		rngInt = Random.Range (0, 2);
		multiply = 1 + (rngInt * victories);
		pleasure = (victories * satisfaction * rngInt) / 2;
		totalRage = multiply * (rage / 2);
		tempSaltGained = (rage - satisfaction) + (totalRage - pleasure) + victories;

		if (tempSaltGained > 200){
			tempSaltGained = tempSaltGained - (rngInt * (1 + pleasure));
		}
		if (tempSaltGained < 0) {
			tempSaltGained = 0;
		}

		salt = salt + tempSaltGained;
		GameGlobals.SetSalt (salt);
		
		saltMeter.value = salt;
		screenSaltGained = tempSaltGained.ToString ();
		StartCoroutine (SaltGains ());

		points = points + tempSaltGained;

		if (salt >= 10) {
			unlockRahe = true;
		}
		if (salt >= 100) {
			unlockMayyyh = true;
		}
		if (salt >= 200) {
			unlockStayyr = true;
		}
		if (salt >= 500) {
			unlockAwesome = true;
		}
		if (salt >= 750) {
			unlockMoba = true;
		}
		if (salt >= 750 && victories >= 1) {
			unlockKnights = true;
		}
		if (unlockRahe == true) {
			startRaheButton.interactable = true;
		}
		if (unlockMayyyh == true) {
			startMayyhemButton.interactable = true;
		}
		if (unlockStayyr == true) {
			startStartButton.interactable = true;
		}
		if (unlockAwesome == true) {
			startAwesomeButton.interactable = true;
		}
		if (unlockMoba == true) {
			startMobaButton.interactable = true;
		}
		if (unlockKnights == true) {
			startKnightsButton.interactable = true;
		}
	}

	IEnumerator SaltGains()
	{		
		seaWater = GameGlobals.GetSeaWater ();
		seaWater--;
		cookScene.interactable = false;

		saltGained.text = ("Gained " + screenSaltGained + " salt!");
		yield return new WaitForSeconds (1);
		saltGained.text = ("");

		if (seaWater > 0) {
			cookScene.interactable = true;
		}
		GameGlobals.SetSeaWater (seaWater);
	}

	IEnumerator PressQ()
	{
		QSwitchTrue ();
		yield return new WaitForSeconds (delay);
		if (qLeft == true) {
			fail++;
			rage = rage + fail;
			rageMeter.value = rage;
		}
		QSwitchFalse ();
	}
	IEnumerator PressW()
	{
		WSwitchTrue ();
		yield return new WaitForSeconds (delay);
		if (wMiddle == true) {
			fail++;
			rage = rage + fail;
			rageMeter.value = rage;
		}
		WSwitchFalse ();
	}
	IEnumerator PressE()
	{
		ESwitchTrue ();
		yield return new WaitForSeconds (delay);
		if (eRight == true) {
			fail++;
			rage = rage + fail;
			rageMeter.value = rage;
		}
		ESwitchFalse ();
	}

	IEnumerator CompletedGame()
	{
		completed.transform.position = new Vector2 (0, 0);
		yield return new WaitForSeconds (1);
		completed.transform.position = new Vector2 (100, 100);
	}
	
}
