<<<<<<< HEAD
﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Alienship : MonoBehaviour {

	public bool finished = false;
	public Image filler;

	public GameObject _pink;
	public Vector2 _margin;
	public Range[] timeToSpawnAliens;
	//public List<Transform> _spawnPositions;

	int _dificulty;
	bool _isAlive;

	float fullGameTime = 5f;
	float startGameTime = 0f;

	Vector2 _worldSize;

	// Use this for initialization
	IEnumerator Start()
	{
		finished = false;
	    _dificulty = PlayerPrefs.GetInt("difficulty");
	    _isAlive = true;
	    _worldSize.y = Camera.main.orthographicSize;
	    _worldSize.x = _worldSize.y * Camera.main.aspect;
	    _worldSize.y -= _margin.y;
	    _worldSize.x -= _margin.x;
	    if (_dificulty >= timeToSpawnAliens.Length) _dificulty = timeToSpawnAliens.Length - 1;
	    float boundry = (_worldSize.x + 2 * _margin.x);
		while (_isAlive && filler.fillAmount > 0.15f)
	    {
			GameObject obj = Instantiate(_pink);
	        Vector3 pos = new Vector3(Random.Range(-_worldSize.x,_worldSize.x) , Random.Range(-_worldSize.y,_worldSize.y), 0);
			obj.transform.position = pos;
			PinkPanther pinky = obj.GetComponent<PinkPanther>();
			//pinky._targetPosition = pos;
	        pinky.Difficulty = _dificulty;
	        //pinky.GetLarger();
	        yield return new WaitForSeconds(timeToSpawnAliens[_dificulty].Value);
	    }
	}
	
	// Update is called once per frame
	void Update () {
		filler.fillAmount = ((fullGameTime - (Time.time - startGameTime)) / fullGameTime);

		if (filler.fillAmount <= 0)
		{
			print("done");
			finished = true;
			_isAlive = false;
			//Time.timeScale = 0.01f;
		}
	}
}
=======
﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Alienship : MonoBehaviour {

	public bool finished = false;
	public Image filler;

	public GameObject _pink;
	public Vector2 _margin;
	public Range[] timeToSpawnAliens;
	//public List<Transform> _spawnPositions;

	int _dificulty;
	bool _isAlive;

	float fullGameTime = 5f;
	float startGameTime = 0f;

	Vector2 _worldSize;

	// Use this for initialization
	IEnumerator Start()
	{
		finished = false;
	    _dificulty = PlayerPrefs.GetInt("difficulty");
	    _isAlive = true;
	    _worldSize.y = Camera.main.orthographicSize;
	    _worldSize.x = _worldSize.y * Camera.main.aspect;
	    _worldSize.y -= _margin.y;
	    _worldSize.x -= _margin.x;
	    if (_dificulty >= timeToSpawnAliens.Length) _dificulty = timeToSpawnAliens.Length - 1;
	    float boundry = (_worldSize.x + 2 * _margin.x);
		while (_isAlive && filler.fillAmount > 0.15f)
	    {
			GameObject obj = Instantiate(_pink);
	        Vector3 pos = new Vector3(Random.Range(-_worldSize.x,_worldSize.x) , Random.Range(-_worldSize.y,_worldSize.y), 0);
			obj.transform.position = pos;
			PinkPanther pinky = obj.GetComponent<PinkPanther>();
			//pinky._targetPosition = pos;
	        pinky.Difficulty = _dificulty;
	        //pinky.GetLarger();
	        yield return new WaitForSeconds(timeToSpawnAliens[_dificulty].Value);
	    }
	}
	
	// Update is called once per frame
	void Update () {
		filler.fillAmount = ((fullGameTime - (Time.time - startGameTime)) / fullGameTime);

		if (filler.fillAmount <= 0)
		{
			print("done");
			finished = true;
			_isAlive = false;
			//Time.timeScale = 0.01f;
		}
	}
}
>>>>>>> 2ca247e5dd668d6cbb6bc5530b08f455cf55befe
