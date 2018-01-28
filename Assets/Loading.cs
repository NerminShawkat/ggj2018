using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	public string[] news;

	public Sprite[] newsHeadPicture;

	public Text textHead;
	public SpriteRenderer newsPix;


	IEnumerator Start()
    {
		int levelNum = PlayerPrefs.GetInt("level");
		textHead.text = news[levelNum - 2];
		newsPix.sprite = newsHeadPicture[levelNum - 2];
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(levelNum);
    }
}
