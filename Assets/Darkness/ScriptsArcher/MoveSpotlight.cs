using UnityEngine;

public class MoveSpotlight : MonoBehaviour {

	public GameObject renderTex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		renderTex.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 2));
	}
}
