using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public float score;
	public Text HUDscore;
	private string screenScore;

	void Start () {
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
