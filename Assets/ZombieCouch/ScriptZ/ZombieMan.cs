using System.Collections;
using UnityEngine;

public class ZombieMan : MonoBehaviour {

    public static ZombieMan instance;

	public GameObject zombie;

	public RotateHands[] hands;

    bool fst, sec;

	// Use this for initialization
	void Start () {
        instance = this;
        fst = sec = false;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < hands.Length; i++)
		{
			if (hands[i].dead)
			{
                if (i != hands.Length - 1)
                {
                    continue;
                    
                }
            }
			else
				break;
		}
	}

    public void SomeoneDead(int who) {
        if (who == 0)
        {
            fst = true;
        }
        else if (who == 1)
        {
            sec = true;
        }

        if (fst && sec)
        {
            StartCoroutine(DEADS());
        }
    }

    IEnumerator DEADS()
    {
        yield return new WaitForSeconds(2f);
        print("lose");
        PlayerPrefs.SetInt("level", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("loading");
    }
}
