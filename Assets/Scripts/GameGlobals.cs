using UnityEngine;
using System.Collections;

public class GameGlobals : MonoBehaviour {

	public static int salt;
	public static float rage;
	public static float satisfaction;
	public static int seaWater;

	void Start () {
	
	}
	

	void Update () {
	
	}

	public static int GetSalt ()
	{
		return salt;
	}

	public static void SetSalt (int tempSalt)
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
}
