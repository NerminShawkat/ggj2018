using UnityEngine;

public class RotateHands : MonoBehaviour {

	public ParticleSystem ps;
	public SpriteRenderer deadGuy;
	public Sprite deadSprite;

	GameObject lftHand;
	GameObject ritHand;
	GameObject head;

	Vector3 originalPos;

	[HideInInspector]
	public bool lft, rit, caught, dead;

	// Use this for initialization
	void Start()
	{
		lftHand = transform.GetChild(0).gameObject; // +
		//lftHand.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-90f, -179f));
		ritHand = transform.GetChild(1).gameObject; // -
        //ritHand.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(90f, 179f));

		head = transform.GetChild(2).gameObject;
		originalPos = head.transform.position;

		lft = rit = caught = dead = false;
    }

	void Update()
	{
		//print(Quaternion.Angle(lftHand.transform.rotation, Quaternion.Euler(0f, 0f, 30f)));
		//print(Quaternion.Angle(lftHand.transform.rotation, Quaternion.Euler(0f, -105f, 270f)));
		if (Quaternion.Angle(lftHand.transform.rotation, Quaternion.Euler(0f, -80f, 270f)) >= 3f)// Quaternion.Euler(0f, 0f, 30f))
		{
			lftHand.transform.RotateAround(lftHand.transform.position, new Vector3(0f, -1f, 0f), Random.Range(0.1f, 1f));
		} else
		{
			lft = true;
		}

		if (Quaternion.Angle(ritHand.transform.rotation, Quaternion.Euler(0f, 80f, 90f)) >= 3f)// Quaternion.Euler(0f, 0f, 30f))
		{
			ritHand.transform.RotateAround(ritHand.transform.position, new Vector3(0f, 1f, 0f), Random.Range(0.1f, 1f));
		} else
		{
			rit = true;
		}

		if (rit && lft)
		{
			caught = true;
		}

		if (caught && !dead)
		{
			if (Quaternion.Angle(head.transform.rotation, Quaternion.Euler(0f, 0, -25)) >= 3f)// Quaternion.Euler(0f, 0f, 30f))
			{
				head.transform.RotateAround(head.transform.position, new Vector3(0f, 0f, -1f), Random.Range(0.1f, 1f));
				//head.transform.position = Vector3.MoveTowards(originalPos, originalPos - new Vector3(0f, 0.02f), Random.Range(0.1f, 1f));
			} else
			{
				dead = true;
				deadGuy.sprite = deadSprite;
				ps.Play();
			}
		}
	}
}