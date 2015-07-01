using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaltCooker : MonoBehaviour {

	public Slider rageMeter;
	public Slider satisfactionMeter;
	public Slider saltMeter;

	private float rage;
	private float satisfaction;
	private float salt;
	private int victories;

	void Start () {

		salt = GameGlobals.GetSalt ();
		rage = GameGlobals.GetRage ();
		satisfaction = GameGlobals.GetSatisfaction ();
		victories = GameGlobals.GetWins ();

		rageMeter = rageMeter.GetComponent<Slider> ();
		satisfactionMeter = satisfactionMeter.GetComponent<Slider> ();
		saltMeter = saltMeter.GetComponent<Slider> ();

		rageMeter.value = rage;
		satisfactionMeter.value = satisfaction;
		saltMeter.value = salt;
	}
	
	
	void Update () {
	
	}

	public void Cook ()
	{
		int multiply;
		int rngInt;
		float totalRage;
		float pleasure;

		rngInt = Random.Range (0, 2);
		multiply = rngInt * victories /2;
		pleasure = victories * satisfaction * rngInt;
		totalRage = multiply * rage;
		salt = salt + (rage - satisfaction) + (totalRage - pleasure) + victories;
		GameGlobals.SetSalt (salt);

		saltMeter.value = salt;

	}

	public void Back()
	{
		Application.LoadLevel (1);
	}
}
