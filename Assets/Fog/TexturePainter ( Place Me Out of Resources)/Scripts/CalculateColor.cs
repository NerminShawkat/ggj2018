using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateColor : MonoBehaviour {

    public RenderTexture tex;
    public bool capture;
    public Color32 currentColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //capture = true;
            //StartCoroutine(OnPostRender());
        }
	}
    public void CheckColor()
    {
        capture = true;
        //Texture2D t = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32,false);
        //t.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        //t.Apply();
        //return AverageColorFromTexture(t);
    }
    void OnPostRender()
    {
        //print(capture);
        if (capture)
        {
            Texture2D t = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
            t.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            t.Apply();
            currentColor = AverageColorFromTexture(t);
            capture = false;
        }
    }

    public Color32 AverageColorFromTexture(Texture2D tex)
    {

        Color32[] texColors = tex.GetPixels32();

        int total = texColors.Length;

        float r = 0;
        float g = 0;
        float b = 0;

        for (int i = 0; i < total; i++)
        {
            r += texColors[i].r;

            g += texColors[i].g;

            b += texColors[i].b;

        }

        return new Color32((byte)(r / total), (byte)(g / total), (byte)(b / total), 0);

    }
}
