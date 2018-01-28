using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotatoMan : MonoBehaviour {
    float speed;
    private float _sensitivity;
    private Vector3 _rotation;
    private bool _isRotating;
    Rigidbody2D rigidbody2D;
    private int difficulty;
    private int win_Lose;
    private int finalGameScore;
    private void Awake()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");
        win_Lose = 0;
    }
    void Start()
    {
        speed = 5f;
        _sensitivity = 0.2f;
        _rotation = Vector3.zero;
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (difficulty < 1)
            difficulty = 1;
        if (difficulty > 5)
            difficulty = 5;

        rigidbody2D.gravityScale = -1*difficulty;
        finalGameScore = 100 * difficulty;
    }

    private void FixedUpdate()
    {
        float horizental = Input.GetAxis("Horizontal");
        if (horizental < 0)
            horizental *= -1;
        rigidbody2D.gravityScale += horizental * _sensitivity * difficulty;
        if (win_Lose == 1) ;
        //    Application.Lo adLevel("");
        else if (win_Lose == -1) ;
            //Application.LoadLevel("");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "WindTornado")
        {
            
            win_Lose = -1;
        } else if (collision.gameObject.name == "Ground")
        {
            
            win_Lose = 1;
        }
    }
}
