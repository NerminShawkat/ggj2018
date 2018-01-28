using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire_scissors : MonoBehaviour {
    private int difficulty;
    private Rigidbody2D rigidbody2D;
    private float sensativty;
    private float time_Sensativty;
    // Use this for initialization
    void Start () {
        if (difficulty < 0)
            difficulty = 0;
        if (difficulty > 5)
            difficulty = 5;
        rigidbody2D = GetComponent<Rigidbody2D>();
        sensativty = 10000f;
        time_Sensativty = 2.1f - (difficulty/10);
        InvokeRepeating("Give_A_Push", 1, time_Sensativty);
	}
    
    void Give_A_Push()
    {
        rigidbody2D.AddForce(transform.up *sensativty );

    }
    public void set_Defculty(int difficulty)
    {
        this.difficulty = difficulty;
    }

}
