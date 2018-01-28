using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogGameManager : MonoBehaviour {

    [Header("UI Options")]
    public Image remainingTimeImage;

    [Header("Time Options")]
    public float maxTime;
    public float timeMinLimit;
    public float timeMaxLimit;
    public float currentTime;

    [Header("Score Options")]
    public int gameScore;
    public float scoreMultiplier;
    public int numberOfTriggers;
    public int currentNumberOfTriggers;

    [Header("Game Options")]
    public H_GameState currentGameState;
    public GameObject dirstObject;
    //public CalculateColor colorCalculator;
    //public float winAccuracyRate;
    //public Color32 defaultColor;
    //public Color32 currColor;
    //public float checkerMaxTime;
    //float currentCheckerTime;

    // Use this for initialization
    IEnumerator Start () {
        //float r = (currColor.r / defaultColor.r);
        //float g = (currColor.g / defaultColor.g);
        //float b = (currColor.b / defaultColor.b);
        //print("r: " + r + " g: " + g + " b: " + b);
        //print((r + g + b) / 3);
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
                currentGameState = H_GameState.End;
                return;
            }
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    StartCoroutine(CheckForWinning());
            //}

        }
    }

    //public IEnumerator CheckForWinning()
    //{
    //    colorCalculator.CheckColor();
    //    yield return new WaitForSeconds(0.3f);
    //    currColor = colorCalculator.currentColor;
    //    float h1, h2, s1, s2, v1, v2;
    //    Color.RGBToHSV(currColor, out h1, out s1, out v2);
    //    Color.RGBToHSV(defaultColor, out h2, out s2, out v1);
    //    print("The V1 : " + currColor.r);
    //    print("The V2 : " + v2);

    //}

    public void StartTheGame()
    {
        //colorCalculator.CheckColor();
        //yield return new WaitForSeconds(0.1f);
        //defaultColor = colorCalculator.currentColor;
        remainingTimeImage.transform.parent.gameObject.SetActive(true);
        int gameDifficulty = 1;//------ Get the difficulty 
        if (gameDifficulty > 6)
        {
            gameDifficulty = 6;
        }
        maxTime = RemapValue(gameDifficulty, 1, 6, timeMinLimit, timeMaxLimit);

        currentTime = maxTime;
        dirstObject.SetActive(true);
        currentGameState = H_GameState.Playing;
    }
    public float RemapValue(int value, float min1, float max1, float min2, float max2)
    {
        return min2 + (value - min1) * (max2 - min2) / (max1 - min1);
    }

    public void IncreaseTheTriggerCount()
    {
        currentNumberOfTriggers++;
        if (currentNumberOfTriggers >= numberOfTriggers)
        {
            //---Stop he game and Win
            currentGameState = H_GameState.End;
            dirstObject.SetActive(false);
            int extraScore = (int)(gameScore * (currentTime / maxTime));
            print(gameScore + "  " + extraScore);
            HazemUIMan.instance.ShowEndScreen(gameScore + extraScore);
            return;
        }
    }
}
