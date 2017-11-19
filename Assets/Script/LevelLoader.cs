using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public int levelToLoad;
	private string loadPrompt;
	private bool inRange;
	private int completedLevel;
	private bool canLoadLevel;
	public GameObject padlock;

	float timer = 5.0f;
	float startTime;
	float lastTime;
	float elapsedTime;
	 
	void Start()
	{
		completedLevel = PlayerPrefs.GetInt ("Level Completed");
		if (completedLevel == 0) {
			completedLevel = 1;
		}
		canLoadLevel = levelToLoad <= completedLevel ? true : false;

		if (!canLoadLevel) {
			Instantiate(padlock, new Vector3(transform.position.x, -2f , transform.position.z-1),Quaternion.identity);

				}
		}
	void OnTriggerStay(Collider other)
	{
		inRange = true;
		if (canLoadLevel) {
			loadPrompt = (int)timer + " seconds until load level " + levelToLoad.ToString ();
		} else {
			loadPrompt = "Level " + levelToLoad.ToString() + " is Locked";
		}
	}
	void OnTriggerExit()

	{
		inRange = false;
		loadPrompt = "";


	}
	void OnGUI()
	{
		GUI.Label (new Rect (30, Screen.height*.9f, 200,40), loadPrompt);

	}
	void Update(){
		if (canLoadLevel && inRange) {
			HoverTimer ();
		} else
			timer = 5f;

		Debug.Log (inRange);

	}



	void HoverTimer(){
		timer -= Time.deltaTime;

		if (timer < 0f) {
			SceneManager.LoadScene ("Level " + levelToLoad.ToString ());
		}
	}
}
