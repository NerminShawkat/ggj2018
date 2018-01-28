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
    private int gravityStablizer;
    public GameObject head;
    public GameObject blood;
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
        rigidbody2D.gravityScale = 0;
        finalGameScore = 100 * difficulty;
        gravityStablizer = 0;
    }

    private void FixedUpdate()
    {
        float horizental = gravityStablizer;
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
<<<<<<< HEAD
            PlayerPrefs.SetInt("level", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
            UnityEngine.SceneManagement.SceneManager.LoadScene("loading");
=======
            if (head != null)
                head.active = false;
            if (blood != null)
                blood.active = true;
>>>>>>> f38f689eab6b2f3b020ce2377cfb657e458d2c0b
        } else if (collision.gameObject.name == "Ground")
        {
            
            win_Lose = 1;
            PlayerPrefs.SetInt("level", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
            UnityEngine.SceneManagement.SceneManager.LoadScene("loading");
        }
    }
    public void Start_Rising()
    {
        rigidbody2D.gravityScale = -1 * difficulty;
        this.GetComponent<Animator>().enabled = false;
    }
    public void click() { gravityStablizer = 1; }
    public void release() { gravityStablizer = 0; }

}
