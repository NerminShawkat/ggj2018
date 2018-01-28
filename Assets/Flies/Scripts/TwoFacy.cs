using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoFacy : MonoBehaviour {

    [SerializeField] SpriteRenderer _harvy;
    [SerializeField] SpriteRenderer _dent;

    [SerializeField]
    Sprite _deadHarvy;
    [SerializeField]
    Sprite _deadDent;

    private void Start()
    {
        TheLord._OnGameOver.AddListener(OnGameOverHandler);
    }

    void OnGameOverHandler(bool alive)
    {
        if(!alive)
        {
            _harvy.sprite = _deadHarvy;
            _dent.sprite = _deadDent;
        }
    }

    private void OnDestroy()
    {
        TheLord._OnGameOver.RemoveListener(OnGameOverHandler);
    }
}
