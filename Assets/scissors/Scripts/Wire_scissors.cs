using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire_scissors : MonoBehaviour {
    private float speed;
    private int difficulty;
    
	// Use this for initialization
	void Start () {
        if (difficulty < 1)
            difficulty = 1; 
        speed = 0.1f* difficulty;
	}

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y+speed , transform.position.z);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bottom" || collision.gameObject.name == "Upper")
            speed *= -1;
    }
    public void set_Defculty(int difficulty)
    {
        this.difficulty = difficulty;
    }

}
