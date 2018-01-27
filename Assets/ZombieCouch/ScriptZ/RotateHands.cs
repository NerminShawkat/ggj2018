using System;
using System.Collections;
using UnityEngine;

public class RotateHands : MonoBehaviour {

	GameObject lftHand;
	GameObject ritHand;

	// Use this for initialization
	void Start () {
		lftHand = transform.GetChild(0).gameObject; // +
		ritHand = transform.GetChild(1).gameObject; // -

		StartCoroutine(RotateLeftHands());
		StartCoroutine(RotateRightHands());
	}

	void Update()
	{
		//lftHand.transform.rotation = Quaternion.Slerp(lftHand.transform.rotation, new Quaternion(0f, 0f, 20f, 0f), Time.deltaTime);
	}

	IEnumerator RotateOverTime(Quaternion originalRotation, float duration, bool isItLeft)
	{
		if (duration > 0f)
		{
			float startTime = Time.time;
			float endTime = startTime + duration;
			if (isItLeft)
			{
				lftHand.transform.rotation = originalRotation;
			}else
			{
				ritHand.transform.rotation = originalRotation;
			}
			yield return null;
			while (Time.time < endTime)
			{
				float progress = (Time.time - startTime) / duration;
				// progress will equal 0 at startTime, 1 at endTime.
				if (isItLeft)
				{
					lftHand.transform.rotation = Quaternion.Slerp(originalRotation, Quaternion.Euler(0f, 0f, 22f), progress);
				}
				else
				{
					ritHand.transform.rotation = Quaternion.Slerp(originalRotation, Quaternion.Euler(0f, 0f, -30f), progress);
				}
				yield return null;
			}
		}
		if (isItLeft)
		{
			lftHand.transform.rotation = Quaternion.Euler(0f, 0f, 22f);
		} else
		{
			ritHand.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
		}
	}

	IEnumerator RotateLeftHands()
	{
		//lftHand.transform.Rotate(new Vector3(0f, 0f, -230), Space.Self);
		//lftHand.transform.rotation = Quaternion.Slerp(lftHand.transform.rotation, new Quaternion(0f, 0f, 20f, 1f), Time.deltaTime);

		StartCoroutine(RotateOverTime(lftHand.transform.rotation, 5f, true));

		yield return null;
	}

	IEnumerator RotateRightHands()
	{
		//lftHand.transform.Rotate(new Vector3(0f, 0f, 560f), Space.Self);

		StartCoroutine(RotateOverTime(ritHand.transform.rotation, 3f, false));
		yield return null;
	}
}
