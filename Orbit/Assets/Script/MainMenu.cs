using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    public GameObject tutorWindow;
    public GameObject creditWindow;
    public GameObject StartCanvas;
   
    // Use this for initialization
    void Start () {
        Screen.orientation = ScreenOrientation.Landscape;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GameStart()
    {
        Application.LoadLevel(1);
        Time.timeScale = 1f;
    }
    public void Tutorial()
    {
        /*tutorWindow.SetActive(true);
        PlayerPrefs.SetInt("DoTutor", 1);
        */
        Application.LoadLevel(2);
    }
    public void closeTutorial()
    {
        tutorWindow.SetActive(false);
    }
    

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
        //Just to make sure its working
    }
    public void GameMenu()
    {
        Application.LoadLevel(1);
    }
    public void OpenCredit()
    {
        creditWindow.SetActive(true);
    }
    public void CloseCredit()
    {
        creditWindow.SetActive(false);
    }
    public void CloseStartCanvas()
    {
        StartCanvas.SetActive(false);
    }
    public void OpenStartCanvas()
    {
        creditWindow.SetActive(false);
        StartCanvas.SetActive(true);
    }
}
