using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour {
	//public GUISkin skin;
	public int winScreenWidth, winScreenHeight, screenoffset;
    public int continueSize = 250;
    public int newgameSize = 250;
    public int levelSelectSize = 250;
    public int QuitSize = 250;
    public int width = 400;
    public int length = 160;
    public int currentLevel = 0;
    public GameObject Opt,Menu;
    public bool activeState = true;
    //GameManager manager;
    //	Rect windowScreen = new Rect(Screen.width/2-(winScreenWidth*.5f/2), Screen.height/2-(winScreenHeight*.5f/2), winScreenWidth*.5f,winScreenHeight*.5f);
    //void OnGUI()
    //{
    //	GUI.skin = skin;
    //	GUI.Label (new Rect (50, 50, 800, 175), "Cube Slider");
    //	if (PlayerPrefs.GetInt ("Level Completed") > 0) 
    //	{
    //		if (GUI.Button (new Rect (10, continueSize+screenoffset, width, length), "Continue")) 
    //		{
    //			SceneManager.LoadScene (PlayerPrefs.GetInt ("Level Completed"));
    //					}
    //			}
    //	if (GUI.Button (new Rect (10, newgameSize + screenoffset, width, length), "New Game")) {
    //           SceneManager.LoadScene(1);
    //		PlayerPrefs.SetInt("Level Completed",1);
    //			}
    //	if (GUI.Button (new Rect (10, levelSelectSize + screenoffset, width, length), "Level Select")) {
    //           SceneManager.LoadScene("Level Loader");
    //			}
    //	if (GUI.Button (new Rect (10, QuitSize + screenoffset, width, length), "Quit")) 
    //	{
    //		Application.Quit();

    //	}

    //}

    public void NewGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("Level Completed", 1);
        Menu.SetActive(true);

    }
    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level Completed"));
    }
    public void LevelLoader()
    {
        SceneManager.LoadScene("Level Loader");
    }
    public void SaveOnQuit()
    {
        Application.Quit();
    }
    public void Option()
    {
        if (activeState)
        {
            Opt.SetActive(true);
            activeState = false;
        }
        else
        {
            Opt.SetActive(false);
            activeState = true;
        }
    }

}
