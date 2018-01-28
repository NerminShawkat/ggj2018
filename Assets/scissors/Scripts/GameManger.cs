using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManger : MonoBehaviour {
    public Text timeText;
    public Image timerImage;
    private float timer;
    private float timerScale;
    public GameObject wire;
    public GameObject full_Wire;
    public GameObject scissors;
    public GameObject aliveBG;
    public GameObject DeadBG;
    //[HideInInspector]
    private int difficulty;
    [HideInInspector]
    public int win_Lose;

    private int extraScore;
    private int gameScore;
    private int finalScore;
    
    
    private void Awake()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");
        wire.GetComponent<Wire_scissors>().set_Defculty(difficulty);
        if (difficulty < 1)
        difficulty = 1;
        if (difficulty > 6)
            difficulty = 6;
        timer = 6f;
        timeText.text = timer.ToString("F");
        win_Lose = 0;
        int randomChiled = Random.Range(1, full_Wire.transform.childCount-1);
        full_Wire.transform.GetChild(randomChiled).gameObject.AddComponent<BoxCollider2D>();
        full_Wire.transform.GetChild(randomChiled).gameObject.tag="Target";
        full_Wire.transform.GetChild(randomChiled).gameObject.GetComponent<SpriteRenderer>().color =Color.white;
    }
    private void Start()
    {
        timer -= difficulty;
        timerScale = timer;
        gameScore = 100*difficulty;
        aliveBG.active = true;
        DeadBG.active = false;
    }
    private void Update()
    {
        if (win_Lose == 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                timeText.text = timer.ToString("F");
                timerImage.fillAmount = timer / timerScale;
                timeText.color = Color.Lerp(Color.red, Color.white, timer / timerScale);
            }
            else
            {
                timer = 0;
                timeText.text = timer.ToString("F");
                wire.GetComponent<Wire_scissors>().CancelInvoke();
                wire.GetComponent<Wire_scissors>().enabled = false;
                scissors.GetComponent<Scissors_scissors>().enabled = false;
                win_Lose = -1;
                aliveBG.active = false;
                DeadBG.active = true;
                //Application.LoadLevel("");
            }
        }if (win_Lose == 1)
        {
            scissors.GetComponent<Scissors_scissors>().enabled = false;
            extraScore = (int)(timer /timerScale);
            extraScore *= gameScore;
            finalScore = gameScore + extraScore;
           // Application.LoadLevel("");
        }
    }
    public void Win()
    {
        win_Lose = 1;
    }



}
