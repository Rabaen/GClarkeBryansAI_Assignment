using UnityEngine;
using System.Collections;

public class ScrollerText : MonoBehaviour
{
	public string[] intro;
	public float off;
	public float speed = 100;
	GUIStyle largeFont;
	public Font textFont;
	public GUIText title;
	public GUIText title2;
	public float Gtimer = 5;


	void Start()
	{
		largeFont = new GUIStyle();
		largeFont.font = textFont;
		largeFont.alignment = TextAnchor.MiddleCenter;
		largeFont.normal.textColor = Color.cyan;
		//smallFont.fontSize = 10;
		largeFont.fontSize = 40;

	}
	
	public void OnGUI()
	{
		off -= Time.deltaTime * speed;

		if (off >= -1100) 
		{
			for (int i = 0; i < intro.Length; i++) 
			{
				float roff = Screen.height + (i * 20 + off);//(intro.Length*-20) + (i*20 + off);
				float alph = Mathf.Sin ((roff / Screen.height) * 180 * Mathf.Deg2Rad);
				GUI.color = new Color (1, 1, 1, alph);
				GUI.Label (new Rect (0, roff, Screen.width, 20), intro [i], largeFont);
				GUI.color = new Color (1, 1, 1, 1);
			}
		}

		if (off <= -1100)
		{
			Gtimer -= Time.deltaTime;
			if (Gtimer >= 1)
			{
				title.guiText.text = "Battle Beyond the Stars";
				title2.guiText.text = "Battle Beyond the Stars";
			}
			else
			{
				title.guiText.enabled = false;
				title2.guiText.enabled = false;
			}
		}
	}
	
}