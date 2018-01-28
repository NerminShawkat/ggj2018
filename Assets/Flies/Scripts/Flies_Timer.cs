using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Flies_Timer : MonoBehaviour {

    [SerializeField] Image _fillImage;
    float _time;
    [SerializeField] UnityEvent _onTimeOut;
    [SerializeField] float[] _times;

    float _remainingTime;

    private void Start()
    {
        int difficulty = PlayerPrefs.GetInt("difficulty");
        if (difficulty >= _times.Length) difficulty = _times.Length - 1;
        _time = _times[difficulty];
        _remainingTime = _time;
        StartCoroutine("CountTime");
        TheLord._OnGameOver.AddListener((b)=>
        {
            StopCoroutine("CountTime");
        });
    }

    IEnumerator CountTime()
    {
        while(_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
            _fillImage.fillAmount = _remainingTime / _time;
            yield return new WaitForEndOfFrame();
        }
        _onTimeOut.Invoke();
    }
}
