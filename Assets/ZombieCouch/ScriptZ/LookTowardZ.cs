using UnityEngine;

public class LookTowardZ : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Camera.main.transform);
	}
}
