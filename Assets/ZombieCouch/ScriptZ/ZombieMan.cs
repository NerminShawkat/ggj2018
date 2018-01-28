using UnityEngine;

public class ZombieMan : MonoBehaviour {

	public GameObject zombie;

	public RotateHands[] hands;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < hands.Length; i++)
		{
			if (hands[i].caught)
			{
				if (i!=hands.Length-1)
				{
					continue;
				}
				print("lose");
			}
			else
				break;
		}
	}
}
