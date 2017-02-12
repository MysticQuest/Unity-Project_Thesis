using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Text text;
    public Image frame;

    public float alpha;

	// Use this for initialization
	void Start ()
    {
      frame = GameObject.Find("TextFrame").GetComponent<Image>();
      text = GameObject.Find("MainText").GetComponent<Text>();

      InvokeRepeating("Fadeout", 1, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
       alpha = text.canvasRenderer.GetAlpha();

    }

    void Fadeout()
    {
        if ( alpha == 255f)
        {
            Invoke("Fadestart", 2);
        }
    }

    void Fadestart()
    {
        text.CrossFadeAlpha(1f, 1, false);
        frame.CrossFadeAlpha(1f, 1, false);
    }

}
