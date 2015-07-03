using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public float score;
	public Text HUDscore;
	private string screenScore;

	public GameObject rgqt;
	public bool rageQuit;

	public GameObject sse;
	public bool saltyEnding;

	public GameObject epac;
	public bool euphoria;

	public GameObject keyb;
	public bool emone;

	void Start () {
		sse.transform.position = new Vector2 (100, 100);
		rgqt.transform.position = new Vector2 (100, 100);
		epac.transform.position = new Vector2 (100, 100);
		keyb.transform.position = new Vector2 (100, 100);

		saltyEnding = GameGlobals.GetSalted ();
		rageQuit = GameGlobals.GetRageQuit ();
		euphoria = GameGlobals.GetEuphoria ();
		emone = GameGlobals.GetNoMoney ();

		if (rageQuit == true) {
			rgqt.transform.position = new Vector2 (0, 0);
		}
		if (saltyEnding == true) {
			sse.transform.position = new Vector2 (0, 0);
		}
		if (euphoria == true) {
			epac.transform.position = new Vector2 (0, 0);
		}
		if (emone == true) {
			keyb.transform.position = new Vector2 (0, 0);
		}
		score = GameGlobals.GetPoints ();
		screenScore = score.ToString ();
		HUDscore.text = ("Score: " + screenScore); 
	}
	

	void Update () {
		
	}

	public void MainMenu()
	{
		Application.LoadLevel (0);
	}

	public void PlayAgain()
	{
		Application.LoadLevel (1);
		GameGlobals.SetSalt(0);
		GameGlobals.SetRage(0);
		GameGlobals.SetSatisfaction (0);
		GameGlobals.SetSeaWater (0);
		GameGlobals.SetWins (0);
		GameGlobals.SetKeyboard (true);
		GameGlobals.SetKeyBoardHealth (5);
		GameGlobals.SetRageQuit (false);
		GameGlobals.SetNoMoney (false);
		GameGlobals.SetSalted (false);
		GameGlobals.SetEuphoria (false);
		GameGlobals.SetPoints (0);

	}
}
