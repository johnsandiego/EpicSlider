using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
	//count
	public int currentScore;
	public int HighScore;
	public int currentLevel=0;
	public int unlockedLevel;
	public int tokenCount;
	public int totalTokenCount;
	//Timer variables
	public Rect timerRect;
	public Color warningColorTimer;
	public Color defaultColorTimer;
	public float startTime;
	private string currentTime;
    // GUI skins
	public GUISkin skin;
	//reference 
	public GameObject tokenParent;

	private bool completed = false;
	private bool ShowWinScreen = false;
	public int winScreenWidth, winScreenHeight;
    //audio

    void Update()
	{
		if (!completed) {
						startTime -= Time.deltaTime;
						currentTime = string.Format ("{0:0.0}", startTime);
						if (startTime <= 0) {
								startTime = 0;
								// if time runs out goes to menu
								SceneManager.LoadScene ("MainMenu");
						}
				}
	}
	void Start()
	{
		//totalTokenCount = tokenParent.transform.childCount;
		if (PlayerPrefs.GetInt ("Level Completed") > 0) {
						currentLevel = PlayerPrefs.GetInt ("Level Completed");
				} else {
						currentLevel = 0;
				}
						//DontDestroyOnLoad (gameObject);
				
	}

    //
 
	//
	public void CompleteLevel()
	{
		ShowWinScreen = true;
		completed = true;
	}
	void LoadNextLevel(){
		Time.timeScale = 1f;
		if (currentLevel < 10) {
			currentLevel += 1;
			SaveGame();
            SceneManager.LoadScene(currentLevel);
		} 
		else {
			print ("you won!");
            SceneManager.LoadScene("End");
		}
		}
	void SaveGame(){
		PlayerPrefs.SetInt("Level Completed", currentLevel);
		PlayerPrefs.SetInt("Level " + currentLevel.ToString()+" score",currentLevel);

		}

	void OnGUI()
	{
		GUI.skin = skin;
		if (startTime < 5f) {
			skin.GetStyle ("Timer").normal.textColor = warningColorTimer;
		} else {
			skin.GetStyle("Timer").normal.textColor = defaultColorTimer;
		}
		GUI.Label (timerRect, currentTime,skin.GetStyle("Timer"));
		GUI.Label (new Rect (35, 120, 200, 200), tokenCount.ToString() + "/" + totalTokenCount.ToString());

		if (ShowWinScreen) {
		 	Rect winScreenRect = new Rect(Screen.width/2-(winScreenWidth*.5f/2), Screen.height/2-(winScreenHeight*.5f/2), winScreenWidth*.5f,winScreenHeight*.5f);
			GUI.Box(winScreenRect, "You Win!");

			int gameTime = (int)startTime;
			currentScore = (tokenCount*10)* gameTime;

			if(GUI.Button(new Rect(winScreenRect.x+winScreenRect.width , winScreenRect.y+winScreenRect.height-90, 150,40), "Continue"))
			   {
				 LoadNextLevel();
					}
			if(GUI.Button(new Rect(winScreenRect.x+winScreenRect.width , winScreenRect.y+winScreenRect.height-50, 150 ,40), "Quit"))
			{
                SceneManager.LoadScene("MainMenu");
				Time.timeScale = 1f;

			}

			GUI.Label(new Rect(winScreenRect.x + 40, winScreenRect.y + 60,300,60),  currentScore.ToString()+" Points");
			GUI.Label(new Rect(winScreenRect.x+40, winScreenRect.y + 40, 300, 50), "Completed Level " + currentLevel);

			}
		}

	}
