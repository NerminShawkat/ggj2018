using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum H_GameState { Standby, Playing, End}
public class TomatoGameManager : MonoBehaviour {

    [Header("UI Options")]
    public Image remainingTimeImage;
    public GameObject newsObject;

    [Header("Time Options")]
    public float maxTime;
    public float timeMinLimit;
    public float timeMaxLimit;
    public float currentTime;

    [Header("Score Options")]
    public float scoreMultiplier;

    [Header("Game Options")]
    public H_GameState currentGameState;
    public GameObject tomatoHead;
    public float blowRate;
    public float minBlowRate, maxBlowRate;
    public float inflateRate;
    public float minInflateRate, maxInflateRate;
    public float winLimit;

    [Header("Heads Options")]
    public GameObject tomatoHeadIdle;
    public GameObject dentHeadIdle;
    public GameObject tomatoHeadPoision;
    public GameObject dentHeadDead;

    [Header("Effects Options")]
    public ParticleSystem poisionEffect;
    public ParticleSystem bloodExplosion;
    public ParticleSystem bloodSpray;
    // Use this for initialization
    IEnumerator Start () {

        yield return new WaitForSeconds(3);
        StartTheGame();
	}
	
	// Update is called once per frame
	void Update () {
        if (currentGameState == H_GameState.Playing)
        {
            currentTime -= Time.deltaTime;
            remainingTimeImage.fillAmount = currentTime / maxTime;
            if (currentTime <= 0)
            {
                //---Stop he game and lose
                StartCoroutine(LoseTheGame());
                currentGameState = H_GameState.End;
                return;
            }
            if (tomatoHead.transform.localScale.x > 1)
            {
                tomatoHead.transform.localScale -= Vector3.one * inflateRate * Time.deltaTime;
            }
            
            //if (tomatoHead.transform.localScale.x <= loseLimit)
            //{
            //    //----- stop the game and lose
            //    currentGameState = H_GameState.End;
            //    return;
            //}

            if (Input.GetMouseButtonDown(0))
            {
                tomatoHead.transform.localScale += Vector3.one * blowRate * Time.deltaTime;
            }

            if (tomatoHead.transform.localScale.x >= winLimit)
            {
                //----- stop the game and Win
                StartCoroutine(WinTheGame());
                currentGameState = H_GameState.End;
                return;
            }
        }
	}

    IEnumerator LoseTheGame()
    {
        tomatoHeadPoision.SetActive(true);
        tomatoHeadIdle.SetActive(false);
        poisionEffect.Play();
        yield return new WaitForSeconds(2);
        dentHeadDead.SetActive(true);
        dentHeadIdle.SetActive(false);
    }

    IEnumerator WinTheGame()
    {
        //tomatoHeadPoision.SetActive(true);
        tomatoHeadIdle.SetActive(false);
        bloodExplosion.Play();
        yield return new WaitForSeconds(1.2f);
        bloodSpray.Play();
    }

    public void StartTheGame()
    {
        //remainingTimeImage.transform.parent.gameObject.SetActive(true);
        newsObject.SetActive(false);
        int gameDifficulty = 1;//------ Get the difficulty 
        if (gameDifficulty > 6)
        {
            gameDifficulty = 6;
        }
        maxTime = RemapValue(gameDifficulty, 1, 6, timeMinLimit, timeMaxLimit);
        inflateRate = RemapValue(gameDifficulty, 1, 6, minInflateRate, maxInflateRate);
        blowRate = RemapValue(gameDifficulty, 1, 6, minBlowRate, maxBlowRate);

        currentGameState = H_GameState.Playing;
        currentTime = maxTime;
    }

    public float RemapValue(int value, float min1, float max1, float min2, float max2 )
    {
        return min2 + (value - min1) * (max2 - min2) / (max1 - min1);
    }
}
