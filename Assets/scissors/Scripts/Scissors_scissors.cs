using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors_scissors : MonoBehaviour {

    bool thereIsWire;
    bool cut;
    public GameObject wire;
    public GameObject gameManger;
    public GameObject pointer;
    Vector3 _initialPosition;
    Vector3 _finalPosition;
    
    // Use this for initialization
    void Start() {
        thereIsWire = false;
    }

    // Update is called once per frame
    void Update() {
        //if (cut)
        //{
        //animation
        //cut = false;
        //}
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _initialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _initialPosition.z = 0;

        }
        if (Input.GetMouseButton(0))
        {
            _finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _finalPosition.z = 0;
            pointer.transform.position=_finalPosition;
            Ray ray = new Ray(_initialPosition, (_finalPosition - _initialPosition));
            //Debug.DrawRay(_initialPosition, (_finalPosition - _initialPosition));
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            
            if (hit) CheckWire(hit.transform.gameObject);
        }
    }
    void CheckWire(GameObject obj)
    {
        print("hit");
        if (obj.CompareTag("Target"))
        {
            obj.GetComponent<HingeJoint2D>().enabled = false;
            wire.GetComponent<Wire_scissors>().CancelInvoke();
            wire.GetComponent<Wire_scissors>().enabled = false;
            gameManger.GetComponent<GameManger>().Win();

        }
    }
    /*
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Segmant (15)")
            {
                thereIsWire = true;
                wire = collision.gameObject;
            }

        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Segmant (15)")
                thereIsWire = false;
        }
       */
    }
