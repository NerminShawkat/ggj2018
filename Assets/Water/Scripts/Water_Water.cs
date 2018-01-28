using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Water : TheLord {

    [SerializeField] Range[] _waterHeights;
    [SerializeField] int _minHeight;
    int _difficulty;
    [SerializeField] float _minWaterLevel;
    [SerializeField] GameObject _waterDrop;
    [SerializeField]
    float _dropDecreaseRate;
    [SerializeField] Vector3 _surfacePosition;
    bool _mouseExit = false;
    bool _isGameOver;
    float _requiredWaterLevel;

    private static float _waterLevel;


    private void Start()
    {
        _difficulty = PlayerPrefs.GetInt("difficulty");
        _difficulty = 3;
        if (_difficulty >= _waterHeights.Length) _difficulty = _waterHeights.Length - 1;
        _waterLevel = _waterHeights[_difficulty].Value;
        _requiredWaterLevel = _waterLevel;
        transform.position = new Vector3(transform.position.x, _waterLevel, 0);
    }

    private void OnMouseDown()
    {
        if (_isGameOver) return;
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        _waterDrop.transform.position = position;
        _waterDrop.gameObject.SetActive(true);
        _mouseExit = false;
    }
    
    private void OnMouseDrag()
    {
        if (_isGameOver) return;
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        _waterDrop.transform.position = position;
    }
    private void OnMouseUp()
    {
        if (_isGameOver) return;
        _waterDrop.gameObject.SetActive(false);
        if (_mouseExit)
        {
            _requiredWaterLevel = _waterLevel - _dropDecreaseRate;
            transform.position = new Vector3(transform.position.x, _waterLevel, 0);
        }

    }
    private void Update()
    {
        if(_waterLevel > _requiredWaterLevel)
        {
            _waterLevel -= _dropDecreaseRate / 20;
            transform.position = new Vector3(transform.position.x, _waterLevel, 0);
        }
        if(_moveToSurface)
        {
            transform.position = Vector3.MoveTowards(transform.position, _surfacePosition, 0.1f);
        }
        if(_moveToSurface && transform.position == _surfacePosition)
        {
            _reachedSurface = true;
        }
    }

    private void OnMouseExit()
    {
        if (_isGameOver) return;
        _mouseExit = true;
    }

    bool _moveToSurface;
    bool _reachedSurface;
    public void OnTimeUpHandler()
    {
        Debug.Log(_waterLevel <= _minWaterLevel);
        _moveToSurface = _waterLevel > _minWaterLevel;
        _isGameOver = true;
        _OnGameOver.Invoke(_waterLevel <= _minWaterLevel);
    }
}
