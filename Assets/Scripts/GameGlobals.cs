using UnityEngine;
using System.Collections;

public class GameGlobals : MonoBehaviour {

	public static float salt;
	public static float rage;
	public static float satisfaction;
	public static int seaWater;
	public static int winCount;
	public static bool keyboard = true;
	public static int keyboardHealth = 5;

	public static bool rageQuit;
	public static bool noMoney;
	public static bool salted;

	void Start () {
	
	}
	

	void Update () {
	
	}

	public static float GetSalt ()
	{
		return salt;
	}

	public static void SetSalt (float tempSalt)
	{
		salt = tempSalt;
	}	
	public static float GetRage ()
	{
		return rage;
	}
	
	public static void SetRage (float tempRage)
	{
		rage = tempRage;
	}
	public static float GetSatisfaction ()
	{
		return satisfaction;
	}
	
	public static void SetSatisfaction (float tempSatisfaction)
	{
		satisfaction = tempSatisfaction;
	}

	public static int GetWins ()
	{
		return winCount;
	}
	
	public static void SetWins (int tempWin)
	{
		winCount = tempWin;
	}

	public static bool GetKeyboard ()
	{
		return keyboard;
	}
	
	public static void SetKeyboard (bool tempKey)
	{
		keyboard = tempKey;
	}

	public static int GetKeyboardHealth ()
	{
		return keyboardHealth;
	}
	
	public static void SetKeyBoardHealth (int tempKBH)
	{
		keyboardHealth = tempKBH;
	}

	public static bool GetRageQuit()
	{
		return rageQuit;
	}
	
	public static void SetRageQuit (bool tempRQ)
	{
		rageQuit = tempRQ;
	}

	public static bool GetNoMoney ()
	{
		return noMoney;
	}
	
	public static void SetNoMoney (bool tempNM)
	{
		noMoney = tempNM;
	}

	public static bool GetSalted ()
	{
		return salted;
	}
	
	public static void SetSalted (bool tempSalted)
	{
		salted = tempSalted;
	}


}
