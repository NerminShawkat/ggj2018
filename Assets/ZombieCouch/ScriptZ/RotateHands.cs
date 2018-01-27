using UnityEngine;
using System.Collections;

public class RotateHands : MonoBehaviour {

	GameObject lftHand;
	GameObject ritHand;

	// Use this for initialization
	void Start () {
		lftHand = transform.GetChild(0).gameObject; // +
		lftHand.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-90f, -179));
		ritHand = transform.GetChild(1).gameObject; // -
		ritHand.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(90, 179));

		StartCoroutine(RotateLeftHands());
		StartCoroutine(RotateRightHands());
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
					lftHand.transform.rotation = Quaternion.LookRotation(Vector3.right);
					lftHand.transform.rotation = Quaternion.Slerp(originalRotation, Quaternion.Euler(0f, 0f, 30), progress);
					//lftHand.transform.eulerAngles = Vector3.Lerp(originalRotation.eulerAngles, new Vector3(0f, 0f, 30f), progress);
					//lftHand.transform.RotateAround(lftHand.transform.position, new Vector3(0f, 0f, 1f), 1);//(originalRotation.eulerAngles - new Vector3(0f, 0f, 30f)).z / duration / Time.deltaTime);
				}
				else
				{
					lftHand.transform.rotation = Quaternion.LookRotation(Vector3.right);
					ritHand.transform.rotation = Quaternion.Slerp(originalRotation, Quaternion.Euler(0f, 0f, -30f), progress);
					//ritHand.transform.eulerAngles = Vector3.Lerp(originalRotation.eulerAngles, new Vector3(0f, 0f, -30f), progress);
					//ritHand.transform.RotateAround(ritHand.transform.position, new Vector3(0f, 0f, -1f), 1);
				}
				yield return null;
			}
		}
		if (isItLeft)
		{
			lftHand.transform.rotation = Quaternion.Euler(0f, 0f, 30f);
		} else
		{
			ritHand.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
		}
	}

	IEnumerator RotateLeftHands()
	{
		//lftHand.transform.Rotate(new Vector3(0f, 0f, -230), Space.Self);
		//lftHand.transform.rotation = Quaternion.Slerp(lftHand.transform.rotation, new Quaternion(0f, 0f, 20f, 1f), Time.deltaTime);

		StartCoroutine(RotateOverTime(lftHand.transform.rotation, Random.Range(3f, 6f), true));

		yield return null;
	}

	IEnumerator RotateRightHands()
	{
		//lftHand.transform.Rotate(new Vector3(0f, 0f, 560f), Space.Self);

		StartCoroutine(RotateOverTime(ritHand.transform.rotation, Random.Range(3f, 6f), false));
		yield return null;
	}
}
