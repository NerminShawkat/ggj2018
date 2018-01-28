using UnityEngine;
using System.Collections;

public class PinkPanther : MonoBehaviour {

	public float Difficulty = 1f;

	float fullGameTime = 5f;
	float startGameTime = 0f;

	float startPointingTime = 0;
	float hitTime = 0;
	bool somethingHitMe = false;

	float minSpeed = -3f;
	float maxSpeed = 3f;

	float waitTime = 1f;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		//StartCoroutine(PickRandomDirection(0));

		startGameTime = Time.time;
	}

	void Update()
	{
		//filler.fillAmount = ((fullGameTime - (Time.time - startGameTime)) / fullGameTime);

		//if (filler.fillAmount <= 0)
		//{
		//	print("done");
		//	Time.timeScale = 0.01f;
		//}

		if (somethingHitMe)
		{
			//print("hit");
			hitTime = Time.time - startGameTime;

			if (hitTime >= 1f)
			{
				print("kill");
				startPointingTime = hitTime = 0;
				Destroy(gameObject);
			}
		}
	}

	// xORy
	// :: 0 inside borders
	// :: 1 pos +x
	// :: 2 neg -x
	// :: 3 pos +y
	// :: 4 neg -y
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

		yield return new WaitForSeconds(waitTime);

		if (transform.position.x >= 6.5f)
		{
			StartCoroutine(PickRandomDirection(1));
			yield break;
		} else if (transform.position.x <= -6.5f)
		{
			StartCoroutine(PickRandomDirection(2));
			yield break;
		}

		if (transform.position.y >= 3f)
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

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "SpriteMask")
		{
			startPointingTime = Time.time;
			somethingHitMe = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.name == "SpriteMask")
		{
			startPointingTime = hitTime = 0;
			somethingHitMe = false;
		}
	}
}
