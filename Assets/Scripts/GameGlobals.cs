using UnityEngine;
using System.Collections;

public class GameGlobals : MonoBehaviour {

	public static int salt;

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
}
