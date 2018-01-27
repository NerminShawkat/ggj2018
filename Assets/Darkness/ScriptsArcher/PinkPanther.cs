using UnityEngine;
using System.Collections;

public class PinkPanther : MonoBehaviour {

	public float minSpeed = -2f;
	public float maxSpeed = 2f;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine(PickRandomDirection(0));
	}

	// xORy :: 0 no problem
	// :: 1 pos x
	// :: 2 neg x
	// :: 3 pos y
	// :: 4 neg y
	IEnumerator PickRandomDirection(int xORy)
	{
		//transform.right = Random.insideUnitCircle;

		if (xORy == 0)
		{
			rb.velocity = new Vector2(Random.Range(minSpeed, maxSpeed), Random.Range(minSpeed, maxSpeed));
		}
		else if (xORy == 1)
		{
			rb.velocity = new Vector2(Random.Range(minSpeed, 0f), Random.Range(minSpeed, maxSpeed));
		}
		else if (xORy == 2)
		{
			rb.velocity = new Vector2(Random.Range(0f, maxSpeed), Random.Range(minSpeed, maxSpeed));
		}
		else if (xORy == 3)
		{
			rb.velocity = new Vector2(Random.Range(minSpeed, maxSpeed), Random.Range(minSpeed, 0f));
		}
		else if (xORy == 4)
		{
			rb.velocity = new Vector2(Random.Range(minSpeed, maxSpeed), Random.Range(0f, maxSpeed));
		}

		yield return new WaitForSeconds(1f);

		if (transform.position.x >= 6.5f)
		{
			StartCoroutine(PickRandomDirection(1));
			yield break;
		} else if (transform.position.x <= -6.5f)
		{
			StartCoroutine(PickRandomDirection(2));
			yield break;
		}

		if (transform.position.y >= 3.5f)
		{
			StartCoroutine(PickRandomDirection(3));
			yield break;
		}
		else if (transform.position.y <= -3.5f)
		{
			StartCoroutine(PickRandomDirection(4));
			yield break;
		}
		else
		{
			StartCoroutine(PickRandomDirection(0));
			yield break;
		}
	}
}
