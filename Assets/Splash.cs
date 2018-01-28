using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {

        yield return new WaitForSeconds(3);

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
