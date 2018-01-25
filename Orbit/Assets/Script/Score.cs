using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    Text scoreText;
    int score;

    public void ModifyScore(int value)
    {
        
        score += value;
        scoreText.text = "Score : " + score.ToString();
    }
	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        score = 0;
       

	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    
}
