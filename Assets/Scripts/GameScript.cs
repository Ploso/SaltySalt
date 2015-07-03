using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

	private int count;
	private int levelLength;
	private int success;
	private int victories;
	private int seaWater;
	
	private float delay;

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

	private bool unlockRahe = false;
	private bool unlockMayyyh = false;
	private bool unlockStayyr = false;
	private bool unlockAwesome = false;
	private bool unlockMoba = false;
	private bool unlockKnights = false;
	
	public Text winAmount;
	public Text saltGained;
	public Text seaWaterAmount;
	
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

	private bool keyboard;
	private int keyboardHealth;
	public GameObject broken;

	private float points;
	private float victorpoints;
	public Text pointsText;
	private string screenPoints;

	public GameObject completed;

	public AudioSource mainSource;

	public AudioClip keyboardSmash;
	public AudioClip qActivate;
	public AudioClip wActivate;
	public AudioClip eActivate;
	public AudioClip qSuccess;
	public AudioClip wSuccess;
	public AudioClip eSuccess;
	public AudioClip epicFail1;
	public AudioClip epicFail2;
	public AudioClip epicFail3;
	public AudioClip epicFail4;
	public AudioClip epicFail5;
	public AudioClip epicFail6;
	public AudioClip epicFail7;
	public AudioClip epicFail8;
	public AudioClip epicFail9;
	public AudioClip epicFail10;

	private int audioRng;

	public GameObject archer;
	public GameObject archer2;
	private bool startArcher;

	//VARIABLES-------------------------------------------------------------------
	//START-----------------------------------------------------------------------


	void Start () {

		victories = GameGlobals.GetWins ();
		salt = GameGlobals.GetSalt ();
		rage = GameGlobals.GetRage ();
		satisfaction = GameGlobals.GetSatisfaction ();
		keyboard = GameGlobals.GetKeyboard ();
		keyboardHealth = GameGlobals.GetKeyboardHealth ();

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

		mainSource = mainSource.GetComponent<AudioSource> ();

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

		rageMeter.value = rage;
		satisfactionMeter.value = satisfaction;
		saltMeter.value = salt;

		levelPlaying = false;
		startArcher = false;

		saltGained.text = ("");

		rageQuit = false;
		salted = false;
		euphoria = false;

	}


	//START--------------------------------------------------------------------
	//UPDATE-------------------------------------------------------------------


	void Update () {

		screenPoints = points.ToString ();
		screenSeaWater = seaWater.ToString ();
		screenVictories = victories.ToString ();

		pointsText.text = ("Points of saltiness: " + screenPoints);
		seaWaterAmount.text = ("Seawater tanks: " + screenSeaWater);
		winAmount.text = ("Victories: " + screenVictories);

		if (levelPlaying == true && keyboard == true) {
			if (Input.GetButtonDown ("Fire1")) {
				if (qLeft == true) {
					satisfaction = satisfaction + 0.5f;
					success++;
					points = points + success;
					qLeft = false;
					left.interactable = false;
					satisfactionMeter.value = satisfaction;
					fail--;
					mainSource.PlayOneShot(qSuccess);
				} else { 
					fail++;
					satisfaction--;
					success--;
					rage = rage + fail;
					rageMeter.value = rage;
					satisfactionMeter.value = satisfaction;
					AudioRngRage();
				}
				if (startArcher == true) {
					FuckingArchers();
				}
			}
		}

		if (levelPlaying == true && keyboard == true) {
			if (Input.GetButtonDown ("Fire2")) {
				if (wMiddle == true) {
					satisfaction = satisfaction + 0.5f;
					success++;
					points = points + success;
					wMiddle = false;
					middle.interactable = false;
					satisfactionMeter.value = satisfaction;
					fail--;
					mainSource.PlayOneShot(wSuccess);
				} else {
					fail++;
					satisfaction--;
					success--;
					rage = rage + fail;
					rageMeter.value = rage;
					satisfactionMeter.value = satisfaction;
					AudioRngRage();
				}
				if (startArcher == true) {
					FuckingArchers();
				}
			}
		}

		if (levelPlaying == true && keyboard == true) {
			if (Input.GetButtonDown ("Fire3")) {
				if (eRight == true) {
					satisfaction = satisfaction + 0.5f;
					success++;
					points = points + success;
					eRight = false;
					right.interactable = false;
					satisfactionMeter.value = satisfaction;
					fail--;
					mainSource.PlayOneShot(eSuccess);
				} else {
					fail++;
					satisfaction--;
					success--;
					rage = rage + fail;
					rageMeter.value = rage;
					satisfactionMeter.value = satisfaction;
					AudioRngRage();
				}
				if (startArcher == true) {
					FuckingArchers();
				}
			}
		}

		if (Input.GetButtonDown("Jump") && keyboard == true){
			keyboardHealth--;
			rage = rage - 10;
			rageMeter.value = rage;
			GameGlobals.SetRage(rage);
			mainSource.PlayOneShot(keyboardSmash);
			if (keyboardHealth <= 0){
				broken.transform.position = new Vector2 (2.14f, -1.83f);
				keyboard = false;
				GameGlobals.SetKeyboard(keyboard);
				AudioRngRage();
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


	//UPDATE--------------------------------------------------------------
	//METHODS-------------------------------------------------------------


	public void QSwitchTrue ()
	{
		if (qLeft == false) {
			qLeft = true;
		}
		left.interactable = true;
		mainSource.PlayOneShot (qActivate);
		if (startArcher == true) {
			FuckingArchers();
		}
	}

	public void QSwitchFalse ()
	{
		if (qLeft == true) {
			qLeft = false;
		}
		left.interactable = false;
		if (startArcher == true) {
			FuckingArchers();
		}
		GameStarter ();
	}
	
	public void WSwitchTrue ()
	{
		if (wMiddle == false) {
			wMiddle = true;
		}
		middle.interactable = true;
		mainSource.PlayOneShot (wActivate);
		if (startArcher == true) {
			FuckingArchers();
		}
	}

	public void WSwitchFalse ()
	{
		if (wMiddle == true) {
			wMiddle = false;
		}
		middle.interactable = false;
		if (startArcher == true) {
			FuckingArchers();
		}
		GameStarter ();
	}
	
	public void ESwitchTrue ()
	{
		if (eRight == false) {
			eRight = true;
		}
		right.interactable = true;
		mainSource.PlayOneShot (eActivate);
		if (startArcher == true) {
			FuckingArchers();
		}
	}

	public void ESwitchFalse ()
	{
		if (eRight == true) {
			eRight = false;
		}
		right.interactable = false;
		if (startArcher == true) {
			FuckingArchers();
		}
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
				AudioRngRage();
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
			if (keyboard == false){
				buyNewKeyboard.interactable = true;
			}
			startAyyyButton.interactable = true;
			if (victories >= 2) {
				unlockRahe = true;
			} else if (victories > 20){
				startRaheButton.interactable = false;
				unlockRahe = false;
			}
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
			if (victories > 10){
				startAyyyButton.interactable = false;
			}
			levelPlaying = false;
			success = 0;
			startArcher = false;
			archer.transform.position = new Vector2 (100, 100);
			archer2.transform.position = new Vector2 (100, 100);
			StartCoroutine (CompletedGame());
		}
	}

	//METHODS----------------------------------------------------------------
	//LEVELS-----------------------------------------------------------------


	public void StartTheGame()
	{
		lockButtons ();

		delay = 0.9f;
		levelLength = 8;
		victorpoints = 10;
		
		StartCoroutine (StartDelay ());
	}

	public void StartRaheGame()
	{
		lockButtons ();

		delay = 0.8f;
		levelLength = 16;
		victorpoints = 20;
		
		StartCoroutine (StartDelay ());
	}

	public void StartMayyyhemGame()
	{
		lockButtons ();
		
		delay = 0.7f;
		levelLength = 16;
		victorpoints = 50;
		
		StartCoroutine (StartDelay ());
	}

	public void StartStayyrGame()
	{
		lockButtons ();
		
		delay = 0.6f;
		levelLength = 32;
		victorpoints = 100;
		
		StartCoroutine (StartDelay ());
	}

	public void StartAwesomeGame()
	{
		lockButtons ();
		
		delay = 0.55f;
		levelLength = 32;
		victorpoints = 200;
		
		StartCoroutine (StartDelay ());
	}
	
	public void StartMobaGame()
	{
		lockButtons ();

		delay = 0.5f;
		levelLength = 64;
		victorpoints = 500;

		StartCoroutine (StartDelay ());
	}

	public void StartKnightGame()
	{
		lockButtons ();

		delay = 0.4f;
		levelLength = 64;
		victorpoints = 1000;

		startArcher = true;
		FuckingArchers ();

		StartCoroutine (StartDelay ());
	}


	//LEVELS------------------------------------------------------------
	//------------------------------------------------------------------

	
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
			GameGlobals.SetNoMoney(true);
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
		AudioRngRage();

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

		if (salt >= 50) {
			unlockMayyyh = true;
		}
		if (salt >= 100) {
			unlockStayyr = true;
		}
		if (salt >= 200) {
			unlockAwesome = true;
		}
		if (salt >= 500) {
			unlockMoba = true;
		}
		if (salt >= 750 && victories >= 10) {
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

	public void lockButtons()
	{
		levelPlaying = true;
		count = 0;
		success = 0;
		fail = 0;

		qLeft = false;
		wMiddle = false;
		eRight = false;

		left.interactable = false;
		middle.interactable = false;
		right.interactable = false;
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

	public void AudioRngRage()
	{
		audioRng = Random.Range (0, 10);
		if (audioRng == 1) {
			mainSource.PlayOneShot (epicFail1);
		} else if (audioRng == 2) {
			mainSource.PlayOneShot (epicFail2);
		} else if (audioRng == 3) {
			mainSource.PlayOneShot (epicFail3);
		} else if (audioRng == 4) {
			mainSource.PlayOneShot (epicFail4);
		} else if (audioRng == 5) {
			mainSource.PlayOneShot (epicFail5);
		} else if (audioRng == 6) {
			mainSource.PlayOneShot (epicFail6);
		} else if (audioRng == 7) {
			mainSource.PlayOneShot (epicFail7);
		} else if (audioRng == 8) {
			mainSource.PlayOneShot (epicFail8);
		} else if (audioRng == 9) {
			mainSource.PlayOneShot (epicFail9);
		} else if (audioRng == 10) {
			mainSource.PlayOneShot (epicFail10);
		} else {
			mainSource.PlayOneShot (epicFail10);
		}
	}

	public void FuckingArchers()
	{
		archer.transform.position = new Vector2 (Random.Range (-7.8f, 8f), Random.Range (-3.7f, 3.5f));
		archer.transform.rotation = new Quaternion (Random.Range (0, 360), Random.Range (0, 360), 0, 0);
		archer2.transform.position = new Vector2 (Random.Range (-7.8f, 8f), Random.Range (-3.7f, 3.5f));
		archer2.transform.rotation = new Quaternion (Random.Range (0, 360), Random.Range (0, 360), 0, 0);
	}



	//-------------------------------------------------------------------------
	//COROUTINES---------------------------------------------------------------


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
			AudioRngRage();
			fail++;
			success--;
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
			AudioRngRage();
			fail++;
			success--;
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
			AudioRngRage();
			fail++;
			success--;
			rage = rage + fail;
			rageMeter.value = rage;
		}
		ESwitchFalse ();
	}

	IEnumerator CompletedGame()
	{
		completed.transform.position = new Vector2 (0.28f, -0.87f);
		mainSource.PlayOneShot (wSuccess);
		yield return new WaitForSeconds (1);
		completed.transform.position = new Vector2 (100, 100);
	}

	IEnumerator StartDelay()
	{
		yield return new WaitForSeconds (1);
		GameStarter ();
	}
	
}
