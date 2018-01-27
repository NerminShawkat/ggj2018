using UnityEngine;
using System.Collections;

public class RotateHands : MonoBehaviour
{

	GameObject lftHand;
	GameObject ritHand;

	// Use this for initialization
	void Start()
	{
		lftHand = transform.GetChild(0).gameObject; // +
		lftHand.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-90f, -179f));
		ritHand = transform.GetChild(1).gameObject; // -

	}

	void Update()
	{
		//print(Quaternion.Angle(lftHand.transform.rotation, Quaternion.Euler(0f, 0f, 30f)));
		if (Quaternion.Angle(lftHand.transform.rotation, Quaternion.Euler(0f, 0f, 30f)) >= 5f)// Quaternion.Euler(0f, 0f, 30f))
		{
			lftHand.transform.RotateAround(lftHand.transform.position, new Vector3(0f, 0f, 1f), 0.5f);
		}

		if (Quaternion.Angle(ritHand.transform.rotation, Quaternion.Euler(0f, 0f, -30f)) >= 5f)// Quaternion.Euler(0f, 0f, 30f))
		{
			ritHand.transform.RotateAround(ritHand.transform.position, new Vector3(0f, 0f, -1f), 0.5f);
		}
	}
}