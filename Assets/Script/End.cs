using UnityEngine;
using System.Collections;

public class End: MonoBehaviour {
	public GUISkin skin;
	public int winScreenWidth, winScreenHeight;
	void OnGUI()
	{


		GUI.skin = skin;
		GUI.Label (new Rect (10, 10, 800, 175), "Cube Slider");
		GUI.Box (new Rect (400, 400, 800, 175), "GameOver");

		if (GUI.Button (new Rect (10, 350, 200, 80), "New Game")) {
			Application.LoadLevel ("MainMenu");
			print ("its working");
				}
		if (GUI.Button (new Rect (10, 550, 200, 80), "Quit")) 
		{
			Application.Quit();

		}

	}
}
