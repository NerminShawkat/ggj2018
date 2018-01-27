using UnityEngine;

public class MoveAside : MonoBehaviour {

	public bool amIRight = false; 

	void OnMouseDrag()
	{
		transform.RotateAround(transform.parent.position, new Vector3(0f, 0f, 1f), amIRight ? 20f : -20f);
	}
}
