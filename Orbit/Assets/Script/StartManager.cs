using UnityEngine;
using System.Collections;

public class StartManager : MonoBehaviour {
    public GameObject creditWindow;
	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.Landscape;
    }
	
	// Update is called once per frame
	void Update () {
	
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
}
