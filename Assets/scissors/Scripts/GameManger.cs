using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManger : MonoBehaviour {
    public Text timeText;
    private float timer;
    private float timerScale;
    public GameObject wire;
    public GameObject scissors;
    //[HideInInspector]
    private int difficulty;
    [HideInInspector]
    public int win_Lose;
    
    private void Awake()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");
        wire.GetComponent<Wire_scissors>().set_Defculty(difficulty);
        timer = 5f;
        timeText.text = timer.ToString("F");
        win_Lose = 0;
    }
    private void Start()
    {
        if (difficulty > 3)
        {
            if (timer>1f)
                timer -= (difficulty - 3);
        }
        timerScale = timer;
    }
    private void Update()
    {
        if (win_Lose == 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                timeText.text = timer.ToString("F");
                timeText.color = Color.Lerp(Color.red, Color.white, timer / timerScale);
            }
            else
            {
                timer = 0;
                timeText.text = timer.ToString("F");
                wire.GetComponent<Wire_scissors>().enabled = false;
                scissors.GetComponent<Scissors_scissors>().enabled = false;
                win_Lose = -1;
                //Application.LoadLevel("");
            }
        }if (win_Lose == 1)
        {
            scissors.GetComponent<Scissors_scissors>().enabled = false;
           // Application.LoadLevel("");
        }
    }
    public void Win()
    {
        win_Lose = 1;
    }



}
