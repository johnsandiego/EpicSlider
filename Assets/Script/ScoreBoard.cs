using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {
	public GUISkin skin;
	public int windowWidth, windowHeight;
	void OnGUI()
	{
		GUI.skin = skin;	
		Rect winScreenRect = new Rect(Screen.width/2-(windowWidth*.5f/2), Screen.height/2-(windowHeight*.5f/2), windowWidth*.5f,windowHeight*.5f);
		GUI.Box(winScreenRect, "Top Score");
		GUI.Box(new Rect(Screen.width/2-(windowWidth*.5f/3), Screen.height/2-(windowHeight*.5f/3),300,50), "No. 1 " );

	}
}
