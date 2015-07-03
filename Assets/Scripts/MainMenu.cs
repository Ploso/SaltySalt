using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


	void Start () {
	
	}
	

	void Update () {
	
	}

	public void StartGame()
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

	public void InfoScreen()
	{
		Application.LoadLevel (3);
	}

	public void ToTheMainMenu()
	{
		Application.LoadLevel (0);
	}
}
