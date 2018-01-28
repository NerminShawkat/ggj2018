using UnityEngine;

public class RotateHands : MonoBehaviour {

	GameObject lftHand;
	GameObject ritHand;

	public bool lft, rit, caught;

	// Use this for initialization
	void Start()
	{
		lftHand = transform.GetChild(0).gameObject; // +
		lftHand.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-90f, -179f));
		ritHand = transform.GetChild(1).gameObject; // -
        ritHand.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(90f, 179f));

		lft = rit = caught = false;
    }

	void Update()
	{
		//print(Quaternion.Angle(lftHand.transform.rotation, Quaternion.Euler(0f, 0f, 30f)));
		if (Quaternion.Angle(lftHand.transform.rotation, Quaternion.Euler(0f, 0f, 30f)) >= 3f)// Quaternion.Euler(0f, 0f, 30f))
		{
			lftHand.transform.RotateAround(lftHand.transform.position, new Vector3(0f, 0f, 1f), Random.Range(0.1f, 1f));
		} else
		{
			lft = true;
		}

		if (Quaternion.Angle(ritHand.transform.rotation, Quaternion.Euler(0f, 0f, -30f)) >= 3f)// Quaternion.Euler(0f, 0f, 30f))
		{
			ritHand.transform.RotateAround(ritHand.transform.position, new Vector3(0f, 0f, -1f), Random.Range(0.1f, 1f));
		} else
		{
			rit = true;
		}

		if (rit && lft)
		{
			caught = true;
		}
	}
}