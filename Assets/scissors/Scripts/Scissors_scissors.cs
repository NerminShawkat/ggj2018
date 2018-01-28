using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors_scissors : MonoBehaviour {

    bool thereIsWire;
    bool cut;
    GameObject wire;
    public GameObject gameManger;
	// Use this for initialization
	void Start () {
        thereIsWire = false;
	}
	
	// Update is called once per frame
	void Update () {
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
            cut = true;
            if (thereIsWire)
            {
                wire.GetComponent<Wire_scissors>().CancelInvoke();
                wire.GetComponent<Wire_scissors>().enabled = false;
                wire.GetComponent<HingeJoint2D>().enabled = false;
                gameManger.GetComponent<GameManger>().Win();
            }
        }
    }
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
   
}
