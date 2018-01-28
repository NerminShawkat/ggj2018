using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        int levelNum = PlayerPrefs.GetInt("level");
        SceneManager.LoadScene(levelNum);
    }
}
