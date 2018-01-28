using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flies_Swatter : MonoBehaviour {

    [SerializeField] GameObject _theSwatter;
    
    Vector3 _initialPosition;
    Vector3 _finalPosition;

    bool _isGameOver;

    private void Start()
    {
        Flies_FliesLord._OnGameOver.AddListener(OnGameOverHandler);
    }

    private void Update()
    {
        //if(!_isGameOver && Input.GetMouseButtonDown(0))
        //{
        //    _initialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    _initialPosition.z = 0;
        //}
        if(!_isGameOver && Input.GetMouseButtonUp(0))
        {
           // _finalPosition
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            _finalPosition.z = 0;
            
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            //Debug.DrawRay(_initialPosition, (_finalPosition - _initialPosition));
            if(hit)CheckFly(hit.transform.gameObject);
        }
    }

    public void CheckFly(GameObject obj)
    {
        if(obj.CompareTag("Fly"))
        {
            Flies_Fly fly = obj.GetComponent<Flies_Fly>();
            //_theSwatter.transform.position = fly.transform.position;
            //_theSwatter.SetActive(true);
            fly.Die();
            StartCoroutine(RemoveSwatter());
        }
    }

    IEnumerator RemoveSwatter()
    {
        yield return new WaitForSeconds(0.25f);
        _theSwatter.SetActive(false);
    }

    void OnGameOverHandler(bool win)
    {
        _isGameOver = true;
    }
}
