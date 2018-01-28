using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flies_Fly : MonoBehaviour {

    [SerializeField]
    Range[] _stayTime;
    [SerializeField]
    float _largerTime;
    [SerializeField]
    float _scaleIncreaseRate;
    [SerializeField]
    Sprite _deadSprite;
    [SerializeField]
    SpriteRenderer _renderer;
    [SerializeField]
    CircleCollider2D _myCollider;
    
    
    private int _difficulty;
    public int Difficulty
    {
        get
        {
            return _difficulty;
        }
        set
        {
            if (value < _stayTime.Length)
                _difficulty = value;
            else
                _difficulty = _stayTime.Length - 1;
        }
    }

    public Vector3 _targetPosition;

    public void GetLarger()
    {
        StartCoroutine("GetLargerCoroutine");
    }

    private void Start()
    {
        Flies_FliesLord._OnGameOver.AddListener(OnGameOverHandler);
    }
    //private void Update()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, _targetPosition, 0.3f);
    //}

    IEnumerator GetLargerCoroutine()
    {
        yield return new WaitForSeconds(_stayTime[_difficulty].Value);
        int stepsCount =  (int)(_largerTime / 0.03f);
        float scale = 1;
        for (int i = 0; i < stepsCount; i++)
        {
            yield return new WaitForSeconds(0.03f);
            scale += _scaleIncreaseRate;
            transform.localScale = scale * Vector3.one;
        }
        //Flies_FliesLord.BiteMe();
    }

    public void Die()
    {
        _renderer.sprite = _deadSprite;
        Flies_FliesLord.KillFly();
        //StopCoroutine("GetLargerCoroutine");
        Destroy(_myCollider);
        Destroy(gameObject, 1);

    }

    private void OnGameOverHandler(bool win)
    {
        if(win)
        {
            Die();
        }
        else
        {
            // do nothing
        }
    }
    private void OnDestroy()
    {
        Flies_FliesLord._OnGameOver.RemoveListener(OnGameOverHandler);
    }

}
