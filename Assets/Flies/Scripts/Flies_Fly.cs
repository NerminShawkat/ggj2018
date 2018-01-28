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
    [SerializeField] Range RotateSpeed;
    [SerializeField]private Range RadiusRange;
    private float Radius;

    private Vector2 _centre;
    private float _angle;
    float _direction = 1;
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
        if (Random.Range(0, 100) > 50) _direction = -1;
        Radius = RadiusRange.Value;
        _centre = transform.position;
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
        _direction = 0;
        _renderer.sprite = _deadSprite;
        Destroy(GetComponent<Animator>());
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
        TheLord._OnGameOver.RemoveListener(OnGameOverHandler);
    }
    
    private void Update()
    {

        _angle += RotateSpeed.Value * Time.deltaTime * _direction;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }

}
