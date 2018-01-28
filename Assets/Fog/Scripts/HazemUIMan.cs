using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HazemUIMan : MonoBehaviour {

    public static HazemUIMan instance;

    [Header("Score Panel")]
    public GameObject mainPanel;
    public Text finalScore;
    public Text finalExtraScore;
    public AnimationCurve finalPanelAnimCurve;
    public float finalPanelAnimTime;
    public float scoreAnimSpeed;

    [Header("Saving Data Options")]
    public int playerTotalScore;
    // Use this for initialization
    void Start () {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowEndScreen(int currentScore)
    {
        Debug.Log("here");
        

        StartCoroutine(ScaleAnimated(finalPanelAnimCurve, finalPanelAnimTime, currentScore));
    }

    IEnumerator ScaleAnimated(AnimationCurve ac, float time, int currentScore)
    {
        yield return new WaitForSeconds(2);
        PlayerPrefs.SetInt("level", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("loading");
        //finalScore.text = playerTotalScore.ToString();

        //finalExtraScore.text = "+" + currentScore.ToString();

        //float timer = 0.0f;
        //while (timer <= time)
        //{
        //    mainPanel.transform.localScale = Vector3.LerpUnclamped(Vector3.zero, Vector3.one, ac.Evaluate(timer / time));
        //    timer += Time.deltaTime;
        //    yield return null;
        //}

        //StartCoroutine(AnimateScore(playerTotalScore, currentScore));

    }

    IEnumerator AnimateScore(int currentScore, int extraScore)
    {
        int targetScore = currentScore + extraScore;
        
        float lerper = 0;
        while (lerper < 1)
        {
            finalExtraScore.transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(1.2f,1.2f,1.2f), lerper);
            lerper += Time.deltaTime * 5;
            yield return null;
        }
        while (currentScore < targetScore)
        {
            yield return new WaitForSeconds(1 / scoreAnimSpeed);
            currentScore += 1;
            extraScore -= 1;
            finalScore.text = currentScore.ToString();
            finalExtraScore.text = "+"+extraScore.ToString();
        }
        playerTotalScore = currentScore;
        finalExtraScore.gameObject.SetActive(false);
    }
}
