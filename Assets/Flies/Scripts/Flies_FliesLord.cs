using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class Range
{
    [SerializeField] float _min;
    [SerializeField] float _max;

    public float Value
    {
        get
        {
            return Random.Range(_min, _max);
        }
    }
}

public class OnGameOverEvent: UnityEvent<bool>
{

}

public class Flies_FliesLord : TheLord {

    [SerializeField]
    GameObject _fly;
    [SerializeField]
    Range[] _fliesCountRange;
    [SerializeField]List<Transform> _spawnPositions;

    //[SerializeField]
    //Range[] _timeBetweenFlies;
    [SerializeField] Vector2 _margin;
    //[SerializeField] float[] _time;
    


    Vector2 _worldSize;

    int _dificulty;

    static int _fliesCount;

    private static bool _isAlive;

    private void Start()
    {
        _dificulty = PlayerPrefs.GetInt("difficulty");
        _isAlive = true;
        _worldSize.y = Camera.main.orthographicSize;
        _worldSize.x = _worldSize.y * Camera.main.aspect;
        _worldSize.y -= _margin.y;
        _worldSize.x -= _margin.x;
        if (_dificulty >= _fliesCountRange.Length) _dificulty = _fliesCountRange.Length - 1;
        float boundry = (_worldSize.x + 2 * _margin.x);
        _fliesCount = (int)_fliesCountRange[_dificulty].Value;
        for (int i = 0; i < _fliesCount; i++)
        {
            GameObject obj = Instantiate(_fly);
            int positionNumber = Random.Range(0, _spawnPositions.Count);
            obj.transform.position = _spawnPositions[positionNumber].position;
            _spawnPositions.Remove(_spawnPositions[positionNumber]);
        }
    }

    public static void KillFly()
    {
        _fliesCount--;
    }

    //private IEnumerator Start()
    //{
    //    _dificulty = PlayerPrefs.GetInt("difficulty");
    //    _isAlive = true;
    //    _worldSize.y = Camera.main.orthographicSize;
    //    _worldSize.x = _worldSize.y * Camera.main.aspect;
    //    _worldSize.y -= _margin.y;
    //    _worldSize.x -= _margin.x;
    //    if (_dificulty >= _timeBetweenFlies.Length) _dificulty = _timeBetweenFlies.Length - 1;
    //    float boundry = (_worldSize.x + 2 * _margin.x);
    //    while (_isAlive)
    //    {
    //        GameObject obj = Instantiate(_fly);
    //        Vector3 pos = new Vector3(Random.Range(-_worldSize.x,_worldSize.x) , Random.Range(-_worldSize.y,_worldSize.y), 0);
    //        obj.transform.position = new Vector3((pos.x > 0 ? boundry : -boundry), pos.y, pos.z);
    //        Flies_Fly fly = obj.GetComponent<Flies_Fly>();
    //        fly._targetPosition = pos;
    //        fly.Difficulty = _dificulty;
    //        fly.GetLarger();
    //        yield return new WaitForSeconds(_timeBetweenFlies[_dificulty].Value);
    //    }
    //}

    //// the fly will call it to game over the user
    //public static void BiteMe()
    //{
    //    _isAlive = false;
    //    _OnGameOver.Invoke(false);

    //}

    public void OnTimeoutOutHandler()
    {
        if(_fliesCount > 0)
        {
            _OnGameOver.Invoke(false);
        }
        else
        {
            _OnGameOver.Invoke(true);
        }
        PlayerPrefs.SetInt("level", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("loading");
    }
}
