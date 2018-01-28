using UnityEngine;

public class MoveAside : MonoBehaviour {

	public bool amIRight = false; 

	void OnMouseDrag()
	{
		//transform.RotateAround(transform.parent.position, new Vector3(0f, 0f, 1f), amIRight ? 20f : -20f);

		if (Quaternion.Angle(transform.rotation, amIRight ? Quaternion.Euler(0f, 0f, 170f) :  Quaternion.Euler(0f, 0f, -170f)) >= 3f)// Quaternion.Euler(0f, 0f, 30f))
		{
			transform.parent.RotateAround(transform.parent.position, new Vector3(0f, 0f, 1f), amIRight ? 5f : -5f);//Random.Range(0.5f, 1.5f));

			transform.parent.parent.GetComponent<RotateHands>().lft = transform.parent.parent.GetComponent<RotateHands>().rit = false;
		}
	}
}
